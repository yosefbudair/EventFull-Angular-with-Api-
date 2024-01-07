import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public admin:AdminService) { }



    user : any = {};


    async ngOnInit() {
      
     await this.admin.getuserall().then( data => {
      console.log("data is : " , data);
      this.admin.users =  data;
      if (this.admin.users !== null) {
        this.user = this.admin.getuser();
      }
     });
    }
}
