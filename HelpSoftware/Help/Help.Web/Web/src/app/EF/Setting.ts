export class Setting {
  ID_UserSetting: number;
  DefaultValue: string;
  SettingName: string;
  Created: Date;

  deserialize(input): Setting {
    this.ID_UserSetting = input.ID_UserSetting;
    this.DefaultValue = input.DefaultValue;
    this.SettingName = input.SettingName;
    this.Created = input.Created;
    return this;
  }
}
