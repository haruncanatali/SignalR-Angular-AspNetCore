import { Injectable } from '@angular/core';
import { VeriModeli } from './verimodeli';

@Injectable({
  providedIn: 'root'
})
export class TanimService {

  liste : VeriModeli[] = [];

  constructor() { }

  tanimaAl(valux : VeriModeli[]){
    for(let item of valux){
      this.liste.push(item);
    }
  }
  tanimGetir(){
    return this.liste
  }
}
