import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { ApiGET } from '../helpers/generalScripts';
import blog3 from '../public/imgs/blog3.jpg';
import SAVE_WEBSITE_INFORMATION from '../reducers/websiteInformation';
import store from '../store';


//I am going to add the website to the header in the generalScripts so it is attached to every call. 
//Including it in every url is redundant and can be simplified
import { WebsiteTypes } from '../constants/websiteType';
export const Home = () => {
  //let dispatch = useDispatch();
  const [resumeHistory, setResumeHistory] = useState([]);
  const [skillCategories, setSkillCategories] = useState([]);
  useEffect(() => {
      ApiGET(`http://api.mauriceblemons.com/websiteinformation/GetWebsiteById?websiteId=${WebsiteTypes.StandardCoreSite}`, (rc) => {
        //dispatch(SAVE_WEBSITE_INFORMATION(rc.WebsiteInformation))
        setResumeHistory(rc.WebsiteInformation.ResumeObjects);
        setSkillCategories(rc.WebsiteInformation.Skills);
    }, (rc) => {
      console.log(rc);
        //console.log(rc);
    });
  }, []);

  const createResumeItems = () => {
    let items = [];
    resumeHistory.map((resumeItem, i) => {
      items[i] = <div key={i}>
      <h6 class="title text-danger">
        {resumeItem.EmploymentTitle}</h6>
      <h5>
        {resumeItem.CompanyName} - {resumeItem.Location}
      </h5>
      <h6>
        {resumeItem.StartDate} - {resumeItem.EndDate}
      </h6>
      <p class="subtitle">
        {resumeItem.Description.replace('\n', "<br/>")}
      </p></div>;
    });
    return items;
  }

  return <><div class="container-fluid">
    <div id="about" class="row about-section">
      <div class="col-lg-6 about-card">
        <h3 class="font-weight-light">Who am I ?</h3>
        <span class="line mb-5"></span>
        <h5 class="mb-3">Fullstack Software Engineer</h5>
        <p class="mt-20">
          I am experienced and versatile in both front-end and back-end development. With a deep understanding of both client-side and server-side technologies, I am capable of creating end-to-end software solutions.
        </p>
        <p class="mt-20">
          On the front-end, I am very is proficient with such technologies as HTML, CSS3, SASS, and JavaScript. I have nearly a decade of experience developing intuitive and interactive user interfaces. I have experience working with frameworks such as React and Angular to build dynamic web applications with the propers hooks and state management that deliver exceptional user experiences.
        </p>
        <p class="mt-20">
          On the back-end, I utilize the server-side programming CSharp. I am experienced in designing and developing robust APIs, managing databases, and handling server configurations. I have experience with frameworks and technologies like .NET to efficiently build scalable and secure backend systems.
        </p>
        <p class="mt-20">
          With many years of problem-solving, I understand the importance of working independently and collaboratively, whether within my team or with a team in another branch of development or management.
        </p>
        <p class="mt-20">
          Lastly, I understand how to comprehend project requirements and translate them into effective and efficient software solutions. My comprehensive skill set can help create or contribute to viable software development lifecycle, from planning and design to implementation and testing.
        </p>
        <button class="btn btn-outline-danger"><i class="icon-down-circled2 "></i>Download My Resume</button>
      </div>
      <div class="col-lg-6 about-card">
        <h3 class="font-weight-light">Information About This Website and API</h3>
        <span class="line mb-5"></span>
        <ul class="mt40 info list-unstyled">
          <li><span>Hosted in</span> : Azure</li>
          <li><span>Operating System </span> : Linux</li>
          <li><span>Runs On  </span> : NGinx/Docker</li>
        </ul>
        <ul class="social-icons pt-3">
          <li class="social-item"><a class="social-link" href="#"><i class="ti-facebook" aria-hidden="true"></i></a></li>
          <li class="social-item"><a class="social-link" href="#"><i class="ti-twitter" aria-hidden="true"></i></a></li>
          <li class="social-item"><a class="social-link" href="#"><i class="ti-google" aria-hidden="true"></i></a></li>
          <li class="social-item"><a class="social-link" href="#"><i class="ti-instagram" aria-hidden="true"></i></a></li>
          <li class="social-item"><a class="social-link" href="#"><i class="ti-github" aria-hidden="true"></i></a></li>
        </ul>
      </div>
    </div>
  </div><section class="section bg-dark text-center">
      <div class="container">
        <div class="row text-center">
          <div class="col-md-6">
            <div class="row ">
              <div class="col-5 text-right text-light border-right py-3">
                <div class="m-auto"><i class="ti-alarm-clock icon-xl"></i></div>
              </div>
              <div class="col-7 text-left py-3">
                <h1 class="text-danger font-weight-bold font40">6</h1>
                <p class="text-light mb-1">Jobs Worked</p>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="row">
              <div class="col-5 text-right text-light border-right py-3">
                <div class="m-auto"><i class="ti-layers-alt icon-xl"></i></div>
              </div>
              <div class="col-7 text-left py-3">
                <h1 class="text-danger font-weight-bold font40">Sr Software Engineer</h1>
                <p class="text-light mb-1">Current Job Title</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
<section class="section" id="resume">
  <div class="container">
      <h2 class="mb-5"><span class="text-danger">My</span> Resume</h2>
      <div class="row">
          <div class="col-md-4">
              <div class="card">
                  <div class="card-header">
                      <div class="mt-2">
                          <h4>Education</h4>
                          <span class="line"></span>
                      </div>
                  </div>
                  <div class="card-body">
                      <h6 class="title text-danger">Bachelors in Information Technology</h6>
                      <h6>Southern Polytechnic State University</h6>
                      <p class="subtitle">Graduating from Southern Polytechnic State University with a Bachelor's degree in Information Technology was an accomplishment that marked the culmination of years of dedication, hard work, and a deep passion for the field of IT.</p>
                  </div>
              </div>
          </div>
          <div class="col-md-4">
              <div class="card">
                  <div class="card-header">
                      <div class="mt-2">
                          <h4>Employment History</h4>
                          <span class="line"></span>
                      </div>
                  </div>
                  <div class="card-body">
                    { createResumeItems() }
                  </div>
              </div>
          </div>
          <div class="col-lg-4">
              <div class="card">
                  <div class="card-header">
                      <div class="pull-left">
                          <h4 class="mt-2">Skills</h4>
                          <span class="line"></span>
                      </div>
                  </div>    
                  {
                    skillCategories.map((category) => {
                      return <div class="card-body pb-2">

                      <h6><b><u>{category.Name}</u></b></h6>
                      {
                        category.Skills.map((skill) => {
                          <h6>{skill.Name}</h6>

                        })
                      }
                    </div>
                    })
                }
              </div>
          </div>
      </div>
  </div>
</section>

<section class="section bg-dark text-center">
  <div class="container">
      <div class="row text-center">
          <div class="col-md-6">
              <div class="row ">
                  <div class="col-5 text-right text-light border-right py-3">
                      <div class="m-auto"><i class="ti-alarm-clock icon-xl"></i></div>
                  </div>
                  <div class="col-7 text-left py-3">
                      <h1 class="text-danger font-weight-bold font40">6</h1>
                      <p class="text-light mb-1">Viewable Portfolio Projects</p>
                  </div>
              </div>
          </div>
          <div class="col-md-6">
              <div class="row ">
                  <div class="col-5 text-right text-light border-right py-3">
                      <div class="m-auto"><i class="ti-alarm-clock icon-xl"></i></div>
                  </div>
                  <div class="col-7 text-left py-3">
                      <h1 class="text-danger font-weight-bold font40">19</h1>
                      <p class="text-light mb-1">Total Projects</p>
                  </div>
              </div>
          </div>
      </div>
  </div>
</section>

<section class="section" id="blog">
  <div class="container">
      <h2 class="mb-5">Latest <span class="text-danger">Projects</span></h2>
      <div class="row">
          <div class="blog-card">
              <a class="img-holder" href="https://foliocards.net" rel="noreferrer" target="_blank">
                  <img src={blog3} alt="Foliocards" />
              </a>
              <div class="content-holder">
                  <h6 class="title">Foliocards</h6>
                  <p>NFC Business Card E-commerce Store</p>
                  <p>HTML/CSS/JS/C#/EF 6/.NET6</p>

                  <a rel="noreferrer" href="https://foliocards.net" class="read-more">Read more <i class="ti-angle-double-right"></i></a>
              </div>
          </div>
          <div class="blog-card">
              <a rel="noreferrer" class="img-holder" href="https://indieabbey.com/Store" target="_blank">
                  <img src={blog3} alt="IndieAbbey" />
              </a>
              <div class="content-holder">
                  <h6 class="title">IndieAbbey Example Store</h6>
                  <p>Compleptely functional E-commerce Store</p>
                  <p>HTML/CSS/JS/C#/EF 6/.NET6</p>

                  <a rel="noreferrer" href="https://indieabbey.com/Store" class="read-more">Visit <i class="ti-angle-double-right"></i></a>
              </div>
          </div>
          <div class="blog-card">
              <a rel="noreferrer" class="img-holder" href="https://ticketing.indieabbey.com/events" target="_blank">
                  <img src={blog3} alt="IndieAbbey Ticketing" />
              </a>
              <div class="content-holder">
                  <h4 class="title">IndieAbbey Ticketing</h4>
                  <p>A platform individuals use to sell/purchase tickets</p>
                  <p>HTML/CSS/JS/C#/EF 6/.NET6</p>

                  <a rel="noreferrer" href="https://ticketing.indieabbey.com/events" class="read-more">Visit <i class="ti-angle-double-right"></i></a>
              </div>
          </div>
          <div class="blog-card">
              <a class="img-holder" href="https://booking.indieabbey.com/?id=6" target="_blank">
                  <img src={blog3} alt="IndieAbbey Booking" />
              </a>
              <div class="content-holder">
                  <h4 class="title">IndieAbbey Booking</h4>
                  <p>A platform for individuals took book reservsations at events and venues.</p>
                  <p>React/CSS/HTML\Web APIs</p>

                  <a rel="noreferrer" href="https://booking.indieabbey.com/?id=6" class="read-more">Visit <i class="ti-angle-double-right"></i></a>
              </div>
          </div>
          <div class="blog-card">
              <a rel="noreferrer" class="img-holder" href="https://proxy.houlem.com" target="_blank">
                  <img src={blog3} alt="DBLTap.tv" />
              </a>
              <div class="content-holder">
                  <h4 class="title">Live Streaming</h4>
                  <p>Live streaming website that is used to show off livestream technology I have create.</p>

                  <p>Blazor/FFMPEG/SignalR\Web APIs</p>

                  <a rel="noreferrer" href="https://proxy.houlem.com" class="read-more">Visit <i class="ti-angle-double-right"></i></a>
              </div>
          </div>
      </div>
  </div>
</section>
</>
}