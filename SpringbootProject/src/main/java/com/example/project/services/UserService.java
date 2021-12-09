/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.User;
import com.example.project.repositories.UserRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
/**
 *
 * @author vuman
 */
@Service
public class UserService {
     @Autowired
    UserRepository repository;
    
    //list
    public List<User> findAllUser(){
        return (List<User>) repository.findAll();
    }
    public User findOne(int id) {
        User user = repository.findOne(id);
        if (user != null) {
            return user;
        } else {
            return null;
        }
    }
    public User CreateOrUpdate(User user) {
        if (user.getUserid() != null) {
            Optional<User> u = repository.findById(user.getUserid());
            if (u.isPresent()) {
                User newUser = u.get();
                newUser.setEmail(user.getEmail());
                newUser.setIsemployee(user.getIsemployee());
                newUser.setIslead(user.getIsemployee());
                newUser.setPassword(user.getPassword());
                newUser.setPhone(user.getPhone());
                newUser.setUsername(user.getUsername());
                newUser.setAvatar(user.getAvatar());
                newUser.setIsdeleted(user.getIsdeleted());
                newUser.setIsfreelancer(user.getIsfreelancer());
                newUser.setGender(user.getGender());
                newUser.setAddress(user.getAddress());
                newUser.setBirthday(user.getBirthday());
                newUser.setCmndbefore(user.getCmndbefore());
                newUser.setCmndafter(user.getCmndafter());
                newUser = repository.save(newUser);
                return newUser;
            } else {
                user = repository.save(user);
                return user;
            }
        } else {
            user = repository.save(user);
            return user;
        }
    }
    public User Update(int id) {
        Optional<User> u = repository.findById(id);
        User user = repository.findOne(id);
        if (u.isPresent()) {
            user.setIsdeleted(true);
            user = repository.save(user);
            return user;
        } else {
            return null;
        }
    }
}
