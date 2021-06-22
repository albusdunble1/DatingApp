import { AccountService } from './../_services/account.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // parent to child communication because <app-register> is being called from the <app-home> parent
  @Input() usersFromHomeComponent;

  // child to parent
  @Output() cancelRegister = new EventEmitter();
   model:any = {};

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {

  }

  register(){
    console.log(this.model);
    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
      this.cancel();
    }, error => {
      console.log(error);
    })
  }

  cancel(){
    console.log("cancelled");
    this.cancelRegister.emit(false);
  }

}
