export class SystemSetting {
  ID_SystemSetting: number;
  Name: string;
  Value: string;
  Created: Date;

  deserialize(input) {
    this.ID_SystemSetting = input.ID_SystemSetting;
    this.Name = input.Name;
    this.Value = input.Value;
    this.Created = input.Created;
    return this;
  }
}
