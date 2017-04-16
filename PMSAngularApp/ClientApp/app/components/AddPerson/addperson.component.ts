import { Component } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
@Component({
    selector: 'AddPerson',
    template: require('./addperson.component.html')
})
export class AddPersonComponent {
    public Person: Person;
    public httpService: Http;
    constructor(http: Http) {
        this.httpService = http;
    }
    KeyPressedForMobileNo(evt)
    {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;

        if (charCode > 31 && (charCode != 46 && (charCode < 48 || charCode > 57))) {
            return false;
        } else {
            return true;
        }
    }
    AddNewPerson(firstName: string, lastName: string) {
        alert(firstName);
        let headersB = new Headers();
        headersB.append('Content-Type', 'application/json');
        //let options = new RequestOptions({ headers: headersB }); 
        let options = new RequestOptions({ headers: headersB });
        var body = JSON.stringify({ PersonID: 0, FirstName: firstName, LastName: lastName });
        debugger;
        this.httpService.post('api/PersonData/PostPerson', body, options).subscribe(result => {
            // debugger;


        });
    }
}
interface Person {
    PersonID: number;
    PersonName: string;
    PersonDesc: string;
    MobileNo: string;

}