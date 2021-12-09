/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers.hungcontroller;

import com.example.project.entities.Chatroom;
import com.example.project.entities.Groupuser;
import com.example.project.entities.Privatemessage;
import com.example.project.entities.User;
import com.example.project.entities.Zoom;
import com.example.project.services.hungservices.MessageInterface;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

/**
 *
 * @author Admin
 */
@Controller
public class MessageController {
    //init service
    @Autowired
    MessageInterface service;   
    //constructor
    public MessageController(MessageInterface service){
        this.service = service;
    }
    //get all method
    @RequestMapping(value = "/getAllMessage/", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Privatemessage>> findAllMessage() {
        List<Privatemessage> zlist = service.findAllMessageById();
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get 1 method
    @RequestMapping(value = "/getOneMessage/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Privatemessage> findOneMessage(@PathVariable("id") int id) {
      Privatemessage result = new Privatemessage();
      result = service.findOneMessage(id);
      if(result == null)
      {
          return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(result,HttpStatus.OK);
      }
    }
    //Create or Update 1 method
    @RequestMapping(value = "/updateOneMessage/", method = RequestMethod.POST, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Privatemessage> updateCreateMessage(@RequestBody Privatemessage z) {
      Privatemessage result = new Privatemessage();
      result = service.UpdateMessage(z);
      if(result == null)
      {
          return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(result,HttpStatus.OK);
      }
    }
    //delete 1 method
    @RequestMapping(value = "/deleteOneMessage/{id}", method = RequestMethod.DELETE, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Privatemessage> deleteMessage(@PathVariable("id") int id) {
      boolean result = true;
      result = service.DeleteMessage(id);
      if(result)
      {
           return new ResponseEntity<>(HttpStatus.OK); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
    }
    //get all sent method
    @RequestMapping(value = "/getAllMessageSent/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Privatemessage>> findAllMessageSentById(@PathVariable("id") int id) {
        List<Privatemessage> zlist = service.findMessageByIdSent(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get all inbox  method
    @RequestMapping(value = "/getAllMessageInbox/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Privatemessage>> findAllMessageInboxById(@PathVariable("id") int id) {
        List<Privatemessage> zlist = service.findMessageByIdInbox(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    
    //get all method
    @RequestMapping(value = "/getAllUser/", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<User>> findAllUser() {
        List<User> zlist = service.findAllUser();
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get groupuser
    @RequestMapping(value = "/getAllGroupUser/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Groupuser>> findAllGroupUser(@PathVariable("id") int id) {
        List<Groupuser> zlist = service.findAllGroupUser(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get my groupuser
    @RequestMapping(value = "/getAllMyGroupUser/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Groupuser>> findAllMyGroupUser(@PathVariable("id") int id) {
        List<Groupuser> zlist = service.findAllMyGroupUser(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    
}
