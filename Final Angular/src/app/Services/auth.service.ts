import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import jwt_decode from 'jwt-decode';
import { Router } from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import { style } from '@angular/animations';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient , private router:Router , private toastr:ToastrService) {}




  createUser(body:any){

      this.http.post('https://localhost:7043/api/User/Create'
      , body).subscribe((resp: any) =>
      {
      alert('Created Sucessfully');
      }, err => {
      alert('Something wont wrong');
      })
      this.router.navigate(['security/login']);

  }


     Login(text:any,password:any){
      console.log(text , password);
      
      var body:any = {};

    if (text.includes("@") && text.includes(".com")) {
      body = {

        email: text,
  
        password:password
  
      }
      } else {
      body={

      username: text,

      password:password

    }
  }     
      console.log(body);
      const headerDirc = {
        'Contant-Type' : 'application/json',
        'accept' : 'application/json',
      } 
      const requestOption = {
        headers:new HttpHeaders(headerDirc)
      }
      
       this.http.post('https://localhost:7043/api/JWT/token',body , requestOption).subscribe((res : any)=>{
        const response = {
          token:res.toString()
        }
         localStorage.setItem('token' , response.token)
  
        let data:any = jwt_decode(response.token);       
  
        localStorage.setItem('user', JSON.stringify(data));
  
        if(data.role == 1)
          this.router.navigate(['admin/dashboard']);
        else if (data.role==2)
          this.router.navigate(['']);
      },
      err=>{ 
        this.toastr.error('Uncorrect UserName Email or Password!', 'Error', {
          positionClass:'toast-bottom-center',
          closeButton: true,
          progressBar:true
        });
      });
    }


  
}
