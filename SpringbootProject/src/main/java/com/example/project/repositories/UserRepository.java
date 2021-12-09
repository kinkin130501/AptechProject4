/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories;
import com.example.project.entities.User;
import java.util.List;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import java.util.Scanner;

/**
 *
 * @author vuman
 */
public interface UserRepository extends CrudRepository<User, Integer> {
    @Query(value = "SELECT u FROM User u WHERE u.userid = :userid")
    User findOne(@Param("userid") int userid);
    
    @Query(value = "SELECT u FROM User u")
    List<User> findAll();

    @Query(value = "SELECT u FROM User u WHERE u.islead = true")
    List<User> findAllLead();

    @Query(value = "SELECT u FROM User u WHERE u.isemployee = true")
    List<User> findAllEmployee();
}
