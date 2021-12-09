/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories.hungrepo;

import com.example.project.entities.Chatroom;
import com.example.project.entities.Groupuser;
import com.example.project.entities.Privatemessage;
import com.example.project.entities.User;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

/**
 *
 * @author Admin
 */
public interface MessageRepository extends JpaRepository<Privatemessage, Integer> {
    @Query(value ="SELECT p FROM Privatemessage p WHERE p.messageid = :messageid")
    Privatemessage findMessageById(@Param("messageid") int id);
 
    @Query(value ="SELECT p FROM Privatemessage p WHERE p.messagesenderid = :messagesenderid")
    List<Privatemessage> findAllMessageByIdSend(@Param("messagesenderid") int id);
    
    @Query(value ="SELECT p FROM Privatemessage p WHERE p.messagereceiveid = :messagereceiveid")
    List<Privatemessage> findAllMessageByIdInbox(@Param("messagereceiveid") int id);
    //find user
    @Query(value ="SELECT u FROM User u")
    List<User> findAllUser();
    //find groupuser
    @Query(value ="SELECT u FROM Groupuser u WHERE u.groupid = :groupid")
    List<Groupuser> findAllGroupUser(@Param("groupid") int id);
    //find my groupuser
    @Query(value ="SELECT u FROM Groupuser u WHERE u.userid = :userid")
    List<Groupuser> findAllMyGroupUser(@Param("userid") int id);
    
}
