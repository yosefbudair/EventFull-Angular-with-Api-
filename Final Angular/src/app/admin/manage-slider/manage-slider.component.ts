import { Component, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-manage-slider',
  templateUrl: './manage-slider.component.html',
  styleUrls: ['./manage-slider.component.css']
})
export class ManageSliderComponent {
  constructor(public admin:AdminService,public dialog: MatDialog,private router:Router) {}

  updateForm:FormGroup=new FormGroup({
    homeid:new FormControl('',Validators.required),
    image:new FormControl('',Validators.required),
    textt:new FormControl('',Validators.required),
    textp:new FormControl('',Validators.required),
    textd:new FormControl('',Validators.required),
    text4:new FormControl('',Validators.required),
    text5:new FormControl('',Validators.required),
    text6:new FormControl('',Validators.required)
  })


  @ViewChild('callUpdate') callUpdate!:TemplateRef<any>

  async ngOnInit() {
    await this.admin.getAllHome().then((data:any)=>{
      this.admin.homeData = data;
    });
  }

  p_data:any={};
  updateDailog(obj:any){
      this.p_data=obj;
      this.dialog.open(this.callUpdate)
      this.updateForm.controls['homeid'].setValue(this.p_data.homeid);
      this.updateForm.controls['textd'].setValue(this.p_data.textd);
      this.updateForm.controls['text4'].setValue(this.p_data.text4);
      this.updateForm.controls['text5'].setValue(this.p_data.text5);
      this.updateForm.controls['text6'].setValue(this.p_data.text6);
    }

    updateHome(){
      console.log('update Form : ', this.updateForm.value);
      console.log('Image : ', this.admin.displayimgHome );
      this.admin.updateHome(this.updateForm.value);
    }

    uploadImg(file:any){
      if(file.length ==0)
       return  ;
      let fileToUpload=<File> file[0];
      const formData =new FormData();
      formData.append('file',fileToUpload,fileToUpload.name);
      this.admin.uploadAttachmentHome(formData);
    }

    
}
