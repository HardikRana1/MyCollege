import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CollegeServiceProxy, CollegeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  templateUrl: './edit-college-dialog.component.html'
})
export class EditCollegeDialogComponent extends AppComponentBase implements OnInit {
  saving = false;
  college: CollegeDto = new CollegeDto();
  form: FormGroup;

  @ViewChild('form', { static: true }) formTemplate: any;

  constructor(
    injector: Injector,
    private _collegeService: CollegeServiceProxy,
    private fb: FormBuilder,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.createForm();
    this.loadCollege();
  }

  createForm(): void {
    this.form = this.fb.group({
      id: [this.college.id],
      name: [this.college.name, Validators.required],
      address: [this.college.address, Validators.required],
      description: [this.college.description],
    });
  }

  loadCollege(): void {
    this._collegeService
      .get(this.bsModalRef.content.id)
      .subscribe((result: CollegeDto) => {
        this.college = result;
        this.form.patchValue(result);
      });
  }

  save(): void {
    if (this.form.invalid) {
      return;
    }

    this.saving = true;

    this._collegeService
      .update(this.form.value)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.success(this.l('SavedSuccessfully'));
        this.bsModalRef.content.onSave.emit();
        this.bsModalRef.hide();
      });
  }
}
