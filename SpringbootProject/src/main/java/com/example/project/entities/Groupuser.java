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
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author vuchu
 */
@Entity
@Table(name = "Groupuser")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Groupuser.findAll", query = "SELECT g FROM Groupuser g"),
    @NamedQuery(name = "Groupuser.findById", query = "SELECT g FROM Groupuser g WHERE g.id = :id"),
    @NamedQuery(name = "Groupuser.findByIsleader", query = "SELECT g FROM Groupuser g WHERE g.isleader = :isleader")})
public class Groupuser implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "id")
    private Integer id;
    @Column(name = "isleader")
    private Boolean isleader;
    private Integer groupid;
    private Integer userid;

    public Groupuser() {
    }

    public Groupuser(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Boolean getIsleader() {
        return isleader;
    }

    public void setIsleader(Boolean isleader) {
        this.isleader = isleader;
    }

    public Integer getGroupid() {
        return groupid;
    }

    public void setGroupid(Integer groupid) {
        this.groupid = groupid;
    }

    public Integer getUserid() {
        return userid;
    }

    public void setUserid(Integer userid) {
        this.userid = userid;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Groupuser)) {
            return false;
        }
        Groupuser other = (Groupuser) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Groupuser[ id=" + id + " ]";
    }
    
}
