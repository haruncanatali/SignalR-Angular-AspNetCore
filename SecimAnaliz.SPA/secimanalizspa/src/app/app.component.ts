import { Component } from '@angular/core';
import * as signalR from '@microsoft/signalr'
import { IntlService } from "@progress/kendo-angular-intl";
import { LegendLabelsContentArgs } from "@progress/kendo-angular-charts";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  connection : signalR.HubConnection;
  public seriesData : TransactionModule[] = [];
  counter  = 0;

  constructor(){
    this.seriesData = this.seriesData
    this.connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44352/oyhub").configureLogging(signalR.LogLevel.Trace).build();
    this.connection.start(); 
    this.connection.on("receiveMessage",(message) => {
      this.seriesData = message
    }); 
  }

  sayacArttir(){
    this.counter++;
    return this.counter;
  }
  sayacSifirla(){
    this.counter = 0;
  }

  ngOnInit() {
  }
    
}

export class TransactionModule{
  label:string="merhaba";
  value:number=123;
}
