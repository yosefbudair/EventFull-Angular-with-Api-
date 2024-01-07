import { Component, OnInit, ViewChild } from '@angular/core';
import DatalabelsPlugin from 'chartjs-plugin-datalabels';
import { Chart, ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { AdminService } from 'src/app/Services/admin.service';
import { UserService } from 'src/app/Services/user.service';
import { GuestService } from 'src/app/Services/guest.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(public admin:AdminService , public us:UserService , public guest:GuestService) { }
  pieChartData: ChartData<'bar', number[], string | string[]> = { labels: [],
  datasets: []};

  lengthuser : any ;
  lengthevets : any ;
  lengthcategory : any;
  lengthtes : any;
  maxeventregistered : any;
  nummaxregisterd : number = 0;
  
  getuserbyid(id:any) : any{
    console.log()
    return this.admin.users.find((u:any) => u.userid == id);
  }

  async ngOnInit() {
    await this.admin.getuserall().then( data => {
      
      this.admin.users =  data;
      this.lengthuser = data.filter((user: any) => user.roleid === 2).length;
     });

     await this.admin.getallcategory().then( data => {
      
      this.admin.categorys =  data;
      this.lengthcategory = data.length;
     });

     await this.admin.getAllTestimonial().then( data => {
      this.admin.testimonials =  data.filter((e:any )=> e.isaccepted == 1);
      this.lengthtes = data.length;
     });

     await this.admin.getAllEvents().then( data => {
      
      this.admin.events =  data.filter((event: any) => event.ispayed === 1);
      this.lengthevets = data.filter((event: any) => event.ispayed === 1).length;
      this.pieChartData = {
        labels: [ 'Users' , 'Events Active' , 'Categorys' , 'Testimonial' ],
        datasets: [ {
          data: [ this.lengthuser , this.lengthevets , this.lengthcategory , this.lengthtes ]
        } ]
      };    
     });
     
     await this.us.getAllUserEvents().then(async data => {   
      this.us.registersevent =  data;
      console.log("regiester : " , this.us.registersevent);
     });

     await this.findMosMostAttribute().then(async data => {   
      this.maxeventregistered =  this.admin.events.find((e:any) => e.eventid = data);
      console.log("max : " , this.maxeventregistered , "and the max number is " , this.nummaxregisterd);
     });

     await this.guest.getallReview().then( data => {
      this.guest.reviews = data;
      console.log("all reviews : " , this.guest.reviews);
     });
     
  }

  getcategorybyid(id:any) : any{ 
    return this.admin.categorys.find((c:any )=> c.categoryid == id);
  }

  async findMosMostAttribute() : Promise<any> {
    
    return  new Promise((resolve, reject) => {
      let targetevent = 0;
      let max = 0 ;
      for(const obj of this.admin.events)
      {
        const registersevent = this.us.registersevent.filter((r:any) => r.eventid == obj.eventid );
        if( registersevent.length > max)
        {
          max = registersevent.length;
          targetevent = registersevent[0].eventid;
        }
      }
      this.nummaxregisterd = max;
      resolve(targetevent);
      reject(false);
    });
  }

   
  














//----------------------------------------------------------- chart 1 --------------------------------------------------------


  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  // Pie
  public pieChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    plugins: {
      legend: {      
        display: false,
      },
      datalabels: {
        formatter: (value, ctx) => {
          if (ctx.chart.data.labels) {
            return ctx.chart.data.labels[ctx.dataIndex];
          }
          return ''; // Provide a default return value
        },
      }
    }
  };
  
  pieChartPlugins: any[] = [
    // Define your plugins here
    {
      id: 'custom-labels', // A unique ID for the plugin
      beforeDraw(chart: any) {
        // You can customize the chart before drawing here
        const ctx = chart.ctx;
        const width = chart.width;
        const height = chart.height;

        // Draw custom text or elements on the chart
        ctx.font = '24px Arial';
        
      }
    }
  ];
   

  public pieChartType: ChartType = 'bar';
  //public pieChartPlugins = [ DatalabelsPlugin ];

  // events
  public chartClicked({ event, active }: { event: ChartEvent, active: {}[] }): void {}

  public chartHovered({ event, active }: { event: ChartEvent, active: {}[] }): void {}
  
}
