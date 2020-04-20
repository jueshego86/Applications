import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {
  /*
  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }
  */
  transform(value: any, ...arg: any): any {
    const resultList = [];
    for(const item of value){
      if(item.userName.indexOf(arg) > -1){
        resultList.push(item);
      }
    }

    return resultList;
  }

}
