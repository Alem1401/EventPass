import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'pluralize',
  standalone: true
})
export class PluralizePipe implements PipeTransform {
  transform(value: number, singular: string, plural?: string): string {
    if (value === 1) {
      return `${value} ${singular}`;
    }
    return `${value} ${plural || singular + 's'}`;
  }
}
