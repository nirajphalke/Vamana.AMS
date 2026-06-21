
export interface MasterField {
  name: string;
  label: string;
  type?: string;
  required?: boolean;
  fkTo?: string;
  visible: boolean;
  text?: string; // for fk fields
  
}

export interface MasterMeta {
  key: string;
  title: string;
  fields: MasterField[];
}
