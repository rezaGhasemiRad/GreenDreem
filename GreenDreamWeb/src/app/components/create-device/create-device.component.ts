import { Component, OnInit } from '@angular/core';
import {Device} from "../../models/device.model";
import {DeviceService} from "../../services/device.service";

@Component({
  selector: 'app-create-device',
  templateUrl: './create-device.component.html',
  styleUrls: ['./create-device.component.css']
})
export class CreateDeviceComponent implements OnInit {

  device: Device = {
    name: '',
    description: ''
  }

  created = false;

  constructor(private deviceService: DeviceService) { }

  ngOnInit(): void {
  }
  createDevice(): void {
    const data = {
      name: this.device.name,
      description: this.device.description
    };

    this.deviceService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.created = true;
        },
        error => {
          console.log(error);
        });
  }

  newDevice(): void {
    this.created = false;
    this.device = {
      name: '',
      description: ''
    };
  }
}
