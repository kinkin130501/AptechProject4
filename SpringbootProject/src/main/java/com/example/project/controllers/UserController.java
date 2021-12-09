/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.User;
import com.example.project.services.UserService;
import java.util.ArrayList;
import java.util.List;
import javax.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.server.ResponseStatusException;
import java.util.Scanner;


/**
 *
 * @author vuman
 */
@Controller
public class UserController {
    
    @Autowired
    UserService service;   
    
    public UserController(UserService service){
        this.service = service;
    }
    @GetMapping(value = "/users", produces = "application/json")    
    public ResponseEntity<List<User>> findAll() {
        try {
            List<User> list = new ArrayList<>();
            list = service.findAllUser();

            return new ResponseEntity<List<User>>(list, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "User Not Found", e);
        }

    }
    @GetMapping("users/{id}")
    public ResponseEntity<User> getUserById(@PathVariable("id") int id) {
        try {
            User entity = service.findOne(id);
            return new ResponseEntity<User>(entity, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Invalid id", e);
        }

    }
    @RequestMapping(value = ("users"),
            produces = "application/json",
            method = RequestMethod.POST)
    public ResponseEntity<User> creareNewUser(@Valid @RequestBody User user) {
        try {
            User saved = service.CreateOrUpdate(user);
            return new ResponseEntity<User>(saved, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    @RequestMapping(
            value = "/users/{id}",
            produces = "application/json",
            method = RequestMethod.PUT)
    public ResponseEntity<User> updateUser(@PathVariable("id") int id) {
        try{
            if(id != 0) {
                User updated = service.Update(id);
                return new ResponseEntity<User>(updated, new HttpHeaders(), HttpStatus.OK);
            } else {
                return new ResponseEntity<User>(null, new HttpHeaders(), HttpStatus.NOT_FOUND);
            }
        }catch(Exception e){
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Update Failed", e);
        }
        
    }
    
}
