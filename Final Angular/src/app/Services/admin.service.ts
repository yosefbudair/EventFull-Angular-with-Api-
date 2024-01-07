import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { async } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class AdminService {

  constructor(private http:HttpClient , private router:Router , private toastr:ToastrService) {}

  users:any = [{}];
  events: any = [{}];
  user:any = {} ;
  categorys:any = [{}]
  display_image :any;
  AboutusData : any = {};
  displayimgAbout : any;
  displayimgAbout1 : any;
  displayimgHome : any;
  displayimgService : any;
  contact : any = [{}];
  homeData : any = {};
  ServicesData : any = [{}];
  testimonials : any = [{}];
  async getuserall() : Promise<any> {
    
    return  new Promise((resolve, reject) => {
     this.http.get('https://localhost:7043/api/User').subscribe((res : any)=>{
      resolve(res);     
      console.log(res);
      reject(false);
    })});
  }  

  getuser() : any{ 
    let us:any = localStorage.getItem('user');
    us = JSON.parse(us);
    return  this.users.find((u:any )=> u.username  == us.name); 
 }

  
  displayimg : any ;
 
  async uploadAttachment(file : FormData ){
        await this.http.post('https://localhost:7043/api/User/uploadImage',file).subscribe((resp:any)=>{        
        this.displayimg = resp.image;
        console.log(resp.image);    
        alert('Image added');
        }, err => {
        alert('Something Wont Wrong');
    });
  }



  async updateProfile(body: any) { 
    //hits Api (create function)
    console.log("body = " , body)

    if(this.displayimg != null)
    body.image = this.displayimg;
    
    this.http.put('https://localhost:7043/api/User/Update'
    , body).subscribe((resp: any) => 
    {
     alert('Update Sucessfully');
     window.location.reload();
    }, err => {
    alert('Something wont wrong');
    });
    
  }

  async updatePass(body: any) { 
    //hits Api (create function)
    console.log("body = " , body)

    if(this.displayimg != null)
    body.image = this.displayimg;
    
    this.http.put('https://localhost:7043/api/User/Update'
    , body).subscribe((resp: any) =>
    {
    alert('Update Sucessfully');
    }, err => {
    alert('Something wont wrong');
    });
    localStorage.clear();
    this.router.navigate(['security/login']);

    

  }
  // ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- Event ----------------------------------------------
// ----------------------------------------------------------------------------------------------------


async getAllEvents() : Promise<any> {
    
  return  new Promise((resolve, reject) => {
   this.http.get('https://localhost:7043/api/Event').subscribe((res : any)=>{     
    resolve(res);     
    
    reject(false);
  })});
}




// ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- Category -----------------------------------------
// ----------------------------------------------------------------------------------------------------
  

  async getallcategory() : Promise<any> {
    
    return  new Promise((resolve, reject) => {
      this.http.get('https://localhost:7043/api/Category').subscribe((res : any)=>{     
      resolve(res);     
      
      reject(false);
    })});
  }


  
  async createCat(body: any) {
    //hits Api (create function)
    // debugger
    body.image = this.display_image;
    this.http.post('https://localhost:7043/api/Category/', body).subscribe(
      (resp: any) => {      
        window.location.reload();

      },
      (err) => {
        alert('Something wont wrong');
      }
    );
    
  }

  


  async UpdateCategory(body: any) {
    // body.image = this.guest.display_image;
    if (this.display_image != null) 
    body.image = this.display_image;
    this.http.put('https://localhost:7043/api/Category/Update/', body)
      .subscribe(
        (resp: any) => {
          alert('Updated Sucessfully');
        },
        (err) => {
          alert('Something wont wrong');
          console.log(err);
        }
      ); 
  }



  async uploadAttachmentCategory(file : FormData ){
    await this.http.post('https://localhost:7043/api/Category/uploadImage',file).subscribe((resp:any)=>{        
    this.display_image = resp.image;
    console.log(resp.image);    
    alert('Image added');
    }, err => {
    alert('Something Wont Wrong');
});
}
// ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- About Us -----------------------------------------
// ----------------------------------------------------------------------------------------------------



async getAboutus() : Promise<any> {
    
  return  new Promise((resolve, reject) => {
    this.http.get('https://localhost:7043/api/AboutUs').subscribe((res : any)=>{     
    resolve(res);     
    
    reject(false);
  })});
}

updateAboutus(body:any){
  // body.imgname=this.display_image;
  const aboutId = {
    id: this.AboutusData.id,
  };
    if(this.displayimgAbout != null)
    body.imagepath = this.displayimgAbout;

    if(this.displayimgAbout1 != null)
    body.image=this.displayimgAbout1;
    
  const requestBody = {...aboutId,...body };
  console.log("body :: " , requestBody);
  this.http.put('https://localhost:7043/api/AboutUs/Update',requestBody).subscribe((resp)=>{
    alert('ok updated Sucessfully');
    window.location.reload();
  },err=>{
    alert(err.status);
  })
}

  async uploadAttachmentAbout(file:FormData) : Promise<any> {
    
    return  new Promise((resolve, reject) => {
      
        this.http.post('https://localhost:7043/api/AboutUs/uploadImage',file).subscribe((resp:any)=>{        
           
           resolve(resp.image);
        },err=>{
          alert('somthing wrong');
        });
      
})
}


// ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- Contact Us ---------------------------------------
// ----------------------------------------------------------------------------------------------------


async getallcontact() : Promise<any> {
  return  new Promise((resolve, reject) => {
 this.http.get('https://localhost:7043/api/ContactUs').subscribe((res : any)=>{
  resolve(res);     

  reject(false);
})});
}

updateContactus(body:any){
  this.http.put('https://localhost:7043/api/ContactUs/Update',body).subscribe((resp)=>{
    alert('ok updated Sucessfully')
    window.location.reload();
  },err=>{
    alert(err.status);
  })
}

// ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- Home ---------------------------------------
// ----------------------------------------------------------------------------------------------------
async getAllHome() : Promise<any> {
  return  new Promise((resolve, reject) => {
 this.http.get('https://localhost:7043/api/Home').subscribe((res : any)=>{
  resolve(res);     

  reject(false);
},err=>{
  console.log(err.status);
  console.log(err.message);
})});
}

updateHome(body:any){
  // body.imgname=this.display_image;

  if(this.displayimgHome != null)
  body.image = this.displayimgHome;

  this.http.put('https://localhost:7043/api/Home/Update',body).subscribe((resp)=>{
    alert('ok updated Sucessfully')
    window.location.reload();
  },err=>{
    alert(err.status);
  })
}

async uploadAttachmentHome(file : FormData ){
  this.http.post('https://localhost:7043/api/Home/uploadImage',file).subscribe((resp:any)=>{        
  this.displayimgHome = resp.image;   
  alert('Image added');
  }, err => {
  alert('Something Wont Wrong');
});
}

// ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- Services -----------------------------------------
// ----------------------------------------------------------------------------------------------------

createServices(body:any){
  if(this.displayimgService != null)
    body.image = this.displayimgService;
    this.http.post('https://localhost:7043/api/Service',body).subscribe((resp)=>{
      alert('Created Sucessfully');
      window.location.reload();
    },err=>{
      alert(err.status);
    })
}

async getAllServices() : Promise<any> {
  return  new Promise((resolve, reject) => {
 this.http.get('https://localhost:7043/api/Service').subscribe((res : any)=>{
  resolve(res);     

  reject(false);
},err=>{
  console.log(err.status);
  console.log(err.message);
})});
}

DeleteServices(id:number){
  this.http.delete('https://localhost:7043/api/Service/Delete/'+id).subscribe((resp:any)=>{
    alert('Deleted !');
    window.location.reload();
  },err=>{
    console.log(err);
  })}


  updateServices(body:any){

    if(this.displayimgService != null)
    body.image = this.displayimgService;
  
    this.http.put('https://localhost:7043/api/Service/Update',body).subscribe((resp)=>{
      alert('ok updated Sucessfully');
      window.location.reload();
    },err=>{
      alert(err.status);
    })
  }

  uploadAttachmentServices(file:FormData){
    this.http.post('https://localhost:7043/api/Service/uploadImage',file).subscribe((resp:any)=>{
      this.displayimgService = resp.image;
      console.log(resp);
    },err=>{
      alert('somthing wrong');
    })
  }

// ----------------------------------------------------------------------------------------------------
// ------------------------------------------------- Testimonial -----------------------------------------
// ----------------------------------------------------------------------------------------------------

  async getAllTestimonial() : Promise<any> {
    return  new Promise((resolve, reject) => {
   this.http.get('https://localhost:7043/api/Testimonial').subscribe((res : any)=>{
    resolve(res);     
  
    reject(false);
  },err=>{
    console.log(err.status);
    console.log(err.message);
  })});
  }


  deleteTestimonial(id:number){
    this.http.delete('https://localhost:7043/api/Testimonial/delete/'+id).subscribe((resp:any)=>{
      alert('Deleted !');
      window.location.reload();
    },err=>{
      console.log(err);
    })}

    updateIsAccepted(body:any){
      this.http.put('https://localhost:7043/api/Testimonial',body).subscribe((resp)=>{
        alert('ok updated Sucessfully');
        window.location.reload();
      },err=>{
        alert(err.status);
      })
    }


}