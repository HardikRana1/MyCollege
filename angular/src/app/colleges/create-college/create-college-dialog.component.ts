import { Component, Injector, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CollegeServiceProxy, CollegeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  templateUrl: './create-college-dialog.component.html'
})
export class CreateCollegeDialogComponent extends AppComponentBase {
  saving = false;
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
  }

  createForm(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      description: [''],
      latitude: [null, Validators.required],
      longitude: [null, Validators.required],
      email: ['', [Validators.required, Validators.email]],
      isActive: [true]
    });
  }

  save(): void {
    if (this.form.invalid) {
      return;
    }

    this.saving = true;

    this._collegeService
      .create(this.form.value)
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
