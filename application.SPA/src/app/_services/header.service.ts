import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';

declare let alertify: any;
@Injectable()
export class HeaderService {

constructor() { }
createHeader(search, searchBy, orderBy, orderType: string, localId, pageNumber, itemsperPage: number, isActive: boolean){
 let header = new HttpHeaders();
    if ( search !== '' && searchBy !== '') {
      header =  header.append('search', search);
      header =  header.append('searchBy', searchBy);
    }
    if ( orderBy !== '' && orderType !== '' ) {
        header =  header.append('orderBy', 'Barcode');
        header =  header.append('orderType', 'ASC');
    }
    if ( pageNumber !== 0 && itemsperPage !== 0 ) {
        header =   header.append('pageNumber', pageNumber + '');
        header =  header.append('itemsperPage', itemsperPage + '');
    }
    if ( localId !== 0) {
        header =   header.append('localId', '' + localId);
    }
    if (isActive) {
        header =   header.append('isActive', '1');
    } else {
        header =  header.append('isActive', '0');
    }
    return header;
}

}

