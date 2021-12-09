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
import javax.persistence.Lob;
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
@Table(name = "Privatemessage")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Privatemessage.findAll", query = "SELECT p FROM Privatemessage p"),
    @NamedQuery(name = "Privatemessage.findByMessageid", query = "SELECT p FROM Privatemessage p WHERE p.messageid = :messageid"),
    @NamedQuery(name = "Privatemessage.findByMessagetitle", query = "SELECT p FROM Privatemessage p WHERE p.messagetitle = :messagetitle"),
    @NamedQuery(name = "Privatemessage.findByMessagesenderid", query = "SELECT p FROM Privatemessage p WHERE p.messagesenderid = :messagesenderid"),
    @NamedQuery(name = "Privatemessage.findByMessagereceiveid", query = "SELECT p FROM Privatemessage p WHERE p.messagereceiveid = :messagereceiveid"),
    @NamedQuery(name = "Privatemessage.findByMessagecreateat", query = "SELECT p FROM Privatemessage p WHERE p.messagecreateat = :messagecreateat"),
    @NamedQuery(name = "Privatemessage.findByMessageupdateat", query = "SELECT p FROM Privatemessage p WHERE p.messageupdateat = :messageupdateat"),
    @NamedQuery(name = "Privatemessage.findByMessageread", query = "SELECT p FROM Privatemessage p WHERE p.messageread = :messageread")})
public class Privatemessage implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "messageid")
    private Integer messageid;
    @Size(max = 255)
    @Column(name = "messagetitle")
    private String messagetitle;
    @Column(name = "messagesenderid")
    private Integer messagesenderid;
    @Column(name = "messagereceiveid")
    private Integer messagereceiveid;
    @Lob
    @Size(max = 2147483647)
    @Column(name = "messagecontent")
    private String messagecontent;
    @Size(max = 255)
    @Column(name = "messagecreateat")
    private String messagecreateat;
    @Size(max = 255)
    @Column(name = "messageupdateat")
    private String messageupdateat;
    @Column(name = "messageread")
    private Integer messageread;

    public Privatemessage() {
    }

    public Privatemessage(Integer messageid) {
        this.messageid = messageid;
    }

    public Integer getMessageid() {
        return messageid;
    }

    public void setMessageid(Integer messageid) {
        this.messageid = messageid;
    }

    public String getMessagetitle() {
        return messagetitle;
    }

    public void setMessagetitle(String messagetitle) {
        this.messagetitle = messagetitle;
    }

    public Integer getMessagesenderid() {
        return messagesenderid;
    }

    public void setMessagesenderid(Integer messagesenderid) {
        this.messagesenderid = messagesenderid;
    }

    public Integer getMessagereceiveid() {
        return messagereceiveid;
    }

    public void setMessagereceiveid(Integer messagereceiveid) {
        this.messagereceiveid = messagereceiveid;
    }

    public String getMessagecontent() {
        return messagecontent;
    }

    public void setMessagecontent(String messagecontent) {
        this.messagecontent = messagecontent;
    }

    public String getMessagecreateat() {
        return messagecreateat;
    }

    public void setMessagecreateat(String messagecreateat) {
        this.messagecreateat = messagecreateat;
    }

    public String getMessageupdateat() {
        return messageupdateat;
    }

    public void setMessageupdateat(String messageupdateat) {
        this.messageupdateat = messageupdateat;
    }

    public Integer getMessageread() {
        return messageread;
    }

    public void setMessageread(Integer messageread) {
        this.messageread = messageread;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (messageid != null ? messageid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Privatemessage)) {
            return false;
        }
        Privatemessage other = (Privatemessage) object;
        if ((this.messageid == null && other.messageid != null) || (this.messageid != null && !this.messageid.equals(other.messageid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Privatemessage[ messageid=" + messageid + " ]";
    }
    
}
