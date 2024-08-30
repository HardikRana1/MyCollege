import { Component, Injector, OnInit, Output, EventEmitter } from '@angular/core';
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
  id: number;  

  @Output() onSave = new EventEmitter<any>();

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
      latitude: [this.college.latitude, Validators.required],
      longitude: [this.college.longitude, Validators.required],
      email: [this.college.email, [Validators.required, Validators.email]],
      isActive: [this.college.isActive]
    });
  }

  loadCollege(): void {
    // Fetch the college data based on the provided ID
    //console.log('college data');
    //console.log(this.id);
    this._collegeService.get(this.id).subscribe((result: CollegeDto) => {
      this.college = result;
      // Patch the form with the fetched data
      this.form.patchValue(result);
    });
  }

  save(): void {
    /*if (this.form.invalid) {
      return;
    }*/

    this.saving = true;

    this._collegeService.update(this.form.value).pipe(
      finalize(() => {
        this.saving = false;
      })
    ).subscribe(() => {
      this.notify.success(this.l('SavedSuccessfully'));
      this.bsModalRef.hide();
      this.onSave.emit();
    });
  }
}
