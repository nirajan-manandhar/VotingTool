import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EmailComponent } from './email.component';
import { FormsModule } from '@angular/forms';

describe('EmailComponent', () => {
  let component: EmailComponent;
  let fixture: ComponentFixture<EmailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should be invaild', async () => {
  //   component.message = "email@email.com";
  //   component.message.includes('@');
  //  expect(component).toBeTruthy();
  // });
});
