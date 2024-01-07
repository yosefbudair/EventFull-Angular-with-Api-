import { Component, OnInit, ViewChild } from '@angular/core';
import { GuestService } from '../Services/guest.service';
import { Router } from '@angular/router';
import { MapInfoWindow, MapMarker } from '@angular/google-maps';
declare var $:any;
@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  constructor(public guest : GuestService,private router:Router){}

  _filterText:string = '';
  Address : any = {};
  markerPositions: google.maps.LatLngLiteral[] = [];
  latitude : any;
  longitude : any;
  center: google.maps.LatLngLiteral = {
    lat: 31.71896521104641,
    lng: 35.96411664268798
  };
  zoom = 7;
  markerOptions: google.maps.MarkerOptions = {
    draggable: false
  };

  async ngOnInit(){  
    await this.guest.getallcategory().then( data => {
      console.log("data is : " , data);
      this.guest.categorys =  data;
     });

     await this.guest.getuserall().then( data => {
      console.log("data is : " , data);
      this.guest.users =  data;
     });
  
    await this.guest.getAllEvents().then( data => {
      console.log("data is : " , data);
      this.guest.events =  data.filter((e:any) => e.ispayed == 1);
     });
     await this.getdata();
     console.log("Events : " , this.guest.events);

     $(function () {
      $('.navbar-toggler').click(function () {
        $('body').toggleClass('noscroll');
      })
    });
    $(window).on("scroll", function () {
      var scroll = $(window).scrollTop();
  
      if (scroll >= 80) {
        $("#site-header").addClass("nav-fixed");
      } else {
        $("#site-header").removeClass("nav-fixed");
      }
    });
  
    //Main navigation Active Class Add Remove
    $(".navbar-toggler").on("click", function () {
      $("header").toggleClass("active");
    });
    $(document).on("ready", function () {
      if ($(window).width() > 991) {
        $("header").removeClass("active");
      }
      $(window).on("resize", function () {
        if ($(window).width() > 991) {
          $("header").removeClass("active");
        }
      });
    }); 
  }

  goToinfo(){
    
    this.router.navigate(['event-info']);
  }

   getUserById (id:any) : any{ 
    return this.guest.users.find((u:any )=> u.userid == id);
  }

  getcategorybyid(id:any) : any{ 
    return this.guest.categorys.find((c:any )=> c.categoryid == id);
  }





  @ViewChild(MapInfoWindow) infoWindow: MapInfoWindow | undefined;
  
  // addMarker(event: google.maps.MapMouseEvent) {
  //     if (event.latLng != null) this.markerPositions.push(event.latLng.toJSON());
  // }
  addMarkerByCoordinates(latitude: number, longitude: number) {
    const position: google.maps.LatLngLiteral = {
      lat: latitude,
      lng: longitude
    };
    this.markerPositions.push(position );
  }
  openInfoWindow(marker: MapMarker) {
      if (this.infoWindow != undefined) this.infoWindow.open(marker);
  }
  

  async getdata(){
        for (const item of this.guest.events) {
            const string = item.address;
        
        const latIndex = string.indexOf("Lat:") + "Lat:".length;
        const lngIndex = string.indexOf("Lng:") + "Lng:".length;

         this.latitude = parseFloat(string.substring(latIndex, string.indexOf("/")));
         this.longitude = parseFloat(string.substring(lngIndex));
         console.log("lat : " , this.latitude , "long : " , this.longitude)

        
        
         this.addMarkerByCoordinates(this.latitude,this.longitude);
        }
       }

}
