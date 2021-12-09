/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers.hungcontroller;

import com.example.project.entities.Zoom;
import com.example.project.services.hungservices.*;
import java.util.List;
import javax.validation.Valid;
import javax.websocket.server.PathParam;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseStatus;

/**
 *
 * @author Admin
 */
@Controller
public class ZoomController {
    //init service
    @Autowired
    ZoomInterface service;   
    //constructor
    public ZoomController(ZoomInterface service){
        this.service = service;
    }
    //get all  team
    @RequestMapping(value = "/getAllTeamZoom/", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Zoom>> findAllTeamZoom() {
        List<Zoom> zlist = service.findAllTeamZoom();
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(zlist,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get all method
    @RequestMapping(value = "/getAllZoom/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Zoom>> findAllZoom(@PathVariable("id") int id) {
        List<Zoom> zlist = service.findAllZoomById(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(zlist,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get all method
    @RequestMapping(value = "/getAllZoomOther/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <List<Zoom>> findAllZoomOther(@PathVariable("id") int id) {
        List<Zoom> zlist = service.findAllZoomByIdOther(id);
        if(zlist.size() == 0)
        {
            return new ResponseEntity<>(zlist,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
        }
        else
        {
            return new ResponseEntity<>(zlist,HttpStatus.OK);
        }
    }
    //get 1 method
    @RequestMapping(value = "/getOneZoom/{id}", method = RequestMethod.GET, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Zoom> findOneZoom(@PathVariable("id") int id) {
      Zoom result = new Zoom();
      result = service.findOneZoom(id);
      if(result == null)
      {
          return new ResponseEntity<>(result,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(result,HttpStatus.OK);
      }
    }
    
    //Create or Update 1 method
    @RequestMapping(value = "/updateOneZoom/", method = RequestMethod.POST, produces = "application/json") // co the thay json bang xml
    public ResponseEntity <Zoom> updateCreateZoom(@RequestBody Zoom z) {
      Zoom result = new Zoom();
      result = service.UpdateZoom(z);
      if(result == null)
      {
          return new ResponseEntity<>(result,HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(result,HttpStatus.OK);
      }
    }
    
    //delete 1 method
    @DeleteMapping(value = "/deleteOneZoom") // co the thay json bang xml
    public ResponseEntity <Zoom> deleteZoom(@RequestBody Zoom z) {
      boolean result = true;
      result = service.DeleteZoom(z);
      if(result)
      {
           return new ResponseEntity<>(HttpStatus.OK); // ko co noi dung thi status no content
      }
      else
      {
          return new ResponseEntity<>(HttpStatus.NO_CONTENT); // ko co noi dung thi status no content
      }
    }
    //handle error
    @ExceptionHandler(Exception.class)
    @ResponseStatus(value = HttpStatus.INTERNAL_SERVER_ERROR, reason = "Error message")
    public void handleError() {
    }
    
}
