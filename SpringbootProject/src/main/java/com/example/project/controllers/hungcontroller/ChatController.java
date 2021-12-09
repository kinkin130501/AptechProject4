/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers.hungcontroller;

import com.example.project.entities.Chatroom;
import com.example.project.services.hungservices.ChatInterface;
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
public class ChatController {
    //init service
    @Autowired
    ChatInterface service;   
    //constructor
    public ChatController(ChatInterface service){
        this.service = service;
    }
    @RequestMapping("/url")
    public String page(Model model) {
        model.addAttribute("attribute", "value");
        return "view.name";
    }
    //get chatroom
    @RequestMapping(value = "/getAllChatRoom/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Chatroom>> findAllChatRoom(@PathVariable("id") int id) {
        List<Chatroom> zlist = service.findAllChatRoom(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //Create or Update 1 method
    @RequestMapping(value = "/updateOneChat/", method = RequestMethod.POST, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Chatroom> updateCreateMessage(@RequestBody Chatroom z) {
      Chatroom result = new Chatroom();
      result = service.UpdateChatRoom(z);
      if(result == null)
      {
          return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(result,HttpStatus.OK);
      }
    }
}
