/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Admin
 */
@Entity
@Table(name = "Chatroom")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Chatroom.findAll", query = "SELECT c FROM Chatroom c"),
    @NamedQuery(name = "Chatroom.findByChatroomid", query = "SELECT c FROM Chatroom c WHERE c.chatroomid = :chatroomid"),
    @NamedQuery(name = "Chatroom.findByChatuserid", query = "SELECT c FROM Chatroom c WHERE c.chatuserid = :chatuserid"),
    @NamedQuery(name = "Chatroom.findByChatusercontent", query = "SELECT c FROM Chatroom c WHERE c.chatusercontent = :chatusercontent"),
    @NamedQuery(name = "Chatroom.findByChatusergroup", query = "SELECT c FROM Chatroom c WHERE c.chatusergroup = :chatusergroup"),
    @NamedQuery(name = "Chatroom.findByChatusercreateat", query = "SELECT c FROM Chatroom c WHERE c.chatusercreateat = :chatusercreateat"),
    @NamedQuery(name = "Chatroom.findByChatuserupdateat", query = "SELECT c FROM Chatroom c WHERE c.chatuserupdateat = :chatuserupdateat")})
public class Chatroom implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "chatroomid")
    private Integer chatroomid;
    @Column(name = "chatuserid")
    private Integer chatuserid;
    @Size(max = 2147483647)
    @Column(name = "chatusercontent")
    private String chatusercontent;
    @Column(name = "chatusergroup")
    private Integer chatusergroup;
    @Size(max = 2147483647)
    @Column(name = "chatusercreateat")
    private String chatusercreateat;
    @Size(max = 50)
    @Column(name = "chatuserupdateat")
    private String chatuserupdateat;

    public Chatroom() {
    }

    public Chatroom(Integer chatroomid) {
        this.chatroomid = chatroomid;
    }

    public Integer getChatroomid() {
        return chatroomid;
    }

    public void setChatroomid(Integer chatroomid) {
        this.chatroomid = chatroomid;
    }

    public Integer getChatuserid() {
        return chatuserid;
    }

    public void setChatuserid(Integer chatuserid) {
        this.chatuserid = chatuserid;
    }

    public String getChatusercontent() {
        return chatusercontent;
    }

    public void setChatusercontent(String chatusercontent) {
        this.chatusercontent = chatusercontent;
    }

    public Integer getChatusergroup() {
        return chatusergroup;
    }

    public void setChatusergroup(Integer chatusergroup) {
        this.chatusergroup = chatusergroup;
    }

    public String getChatusercreateat() {
        return chatusercreateat;
    }

    public void setChatusercreateat(String chatusercreateat) {
        this.chatusercreateat = chatusercreateat;
    }

    public String getChatuserupdateat() {
        return chatuserupdateat;
    }

    public void setChatuserupdateat(String chatuserupdateat) {
        this.chatuserupdateat = chatuserupdateat;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (chatroomid != null ? chatroomid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Chatroom)) {
            return false;
        }
        Chatroom other = (Chatroom) object;
        if ((this.chatroomid == null && other.chatroomid != null) || (this.chatroomid != null && !this.chatroomid.equals(other.chatroomid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.controllers.Chatroom[ chatroomid=" + chatroomid + " ]";
    }
    
}
