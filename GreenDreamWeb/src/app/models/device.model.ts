export class GetAllResponseModel {
  devices?: Device[];
}
export class GetOneResponseModel {
  device: Device;

  constructor() {
    this.device = new Device();
  }
}

export class Device {
  id?: any;
  name?: string;
  description?: string;
}
