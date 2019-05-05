import { Component, OnInit } from '@angular/core';
import { AirplaneService } from '../airplane/shared/airplane.service';
import { Airplane } from '../airplane/shared/airplane.model';
@Component({
  selector: 'app-airplane-criar',
  templateUrl: './airplane-criar.component.html',
  styleUrls: ['./airplane-criar.component.scss']
})
export class AirplaneCriarComponent implements OnInit {

  _aircraft: any;

  constructor(private airplaneService: AirplaneService) { }

  ngOnInit() {
    this._aircraft = new Airplane({});
  }

  cadastrar() {
    this.airplaneService.post(this._aircraft)
  }

}
