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

    AddNewProject(firstName: string, lastName: string, mobileNo:string) {
        alert(firstName);
        let headersB = new Headers();
        headersB.append('Content-Type', 'application/json');
        //let options = new RequestOptions({ headers: headersB }); 
        let options = new RequestOptions({ headers: headersB });
        var body = JSON.stringify({ PersonID: 0, FirstName: firstName, LastName: lastName, MobileNo: mobileNo });
        debugger;
        this.httpService.post('api/ProjectsData/PostPerson', body, options).subscribe(result => {
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