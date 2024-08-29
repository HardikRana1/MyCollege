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
	CreateStudentDto,
	StudentServiceProxy,
	CollegeServiceProxy,
	CollegeDto
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
	templateUrl: 'create-student-dialog.component.html'
  })
  export class CreateStudentDialogComponent extends AppComponentBase implements OnInit {
	saving = false;
	student: CreateStudentDto = new CreateStudentDto();
	colleges: CollegeDto[] = []; // Add this to hold the colleges
  
	@Output() onSave = new EventEmitter<any>();
  
	constructor(
	  injector: Injector,
	  public _studentService: StudentServiceProxy,
	  public _collegeService: CollegeServiceProxy, // Inject CollegeServiceProxy
	  public bsModalRef: BsModalRef
	) {
	  super(injector);
	}
  
	ngOnInit(): void {
	  this.student.isActive = true;
	  this.loadColleges(); // Load colleges on initialization
	}
  
	loadColleges(): void {
	  this._collegeService.getAll('', true, 0, 1000)
		.subscribe((result) => {
		  this.colleges = result.items;
		});
	}
  
	save(): void {
	  this.saving = true;
  
	  this._studentService.create(this.student).subscribe(
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
  