import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  StudentServiceProxy,
  StudentDto,
  CollegeServiceProxy,
  CollegeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-student-dialog.component.html'
})
export class EditStudentDialogComponent extends AppComponentBase
    implements OnInit {
  saving = false;
  student: StudentDto = new StudentDto();
  colleges: CollegeDto[] = [];
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
      injector: Injector,
      public _studentService: StudentServiceProxy,
      public _collegeService: CollegeServiceProxy,
      public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._collegeService.getAll('', undefined, undefined, undefined).subscribe((result) => {
      this.colleges = result.items;
    });

    this._studentService.get(this.id).subscribe((result: StudentDto) => {
      this.student = result;
    });
  }

  save(): void {
    this.saving = true;

    this._studentService.update(this.student).subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
    );
  }
}
