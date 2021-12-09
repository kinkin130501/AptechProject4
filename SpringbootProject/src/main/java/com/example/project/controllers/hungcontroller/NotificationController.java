/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers.hungcontroller;

import com.example.project.entities.Notification;
import com.example.project.services.hungservices.NotificationInterface;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

/**
 *
 * @author Admin
 */
@Controller
public class NotificationController {
    //init service
    @Autowired
    NotificationInterface service;   
    //constructor
    public NotificationController(NotificationInterface service){
        this.service = service;
    }
    //get all  team
    @RequestMapping(value = "/getAllNotification/", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Notification>> findAllNotification() {
        List<Notification> zlist = service.findAll();
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(zlist,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //Create or Update 1 method
    @RequestMapping(value = "/updateOneNotification/", method = RequestMethod.POST, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Notification> updateCreateMessage(@RequestBody Notification z) {
      Notification result = new Notification();
      result = service.UpdateNoti(z);
      if(result == null)
      {
          return new ResponseEntity<>(result,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(result,HttpStatus.OK);
      }
    }
    //update read all
    @RequestMapping(value = "/readAllNotification/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Notification>> readAllNotification(@PathVariable("id") int id) {
        List<Notification> zlist = service.findAllNotiByUserid(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {   
            for(Notification item: zlist)
            {
                item.setNotiread(1);
                service.UpdateNoti(item);
            }
            return new ResponseEntity<>(HttpStatus.OK);
        }
    }
}
