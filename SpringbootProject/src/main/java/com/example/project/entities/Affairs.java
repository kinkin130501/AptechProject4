/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author vuchu
 */
@Entity
@Table(name = "Affairs")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Affairs.findAll", query = "SELECT a FROM Affairs a"),
    @NamedQuery(name = "Affairs.findByAffairid", query = "SELECT a FROM Affairs a WHERE a.affairid = :affairid"),
    @NamedQuery(name = "Affairs.findByAffairname", query = "SELECT a FROM Affairs a WHERE a.affairname = :affairname"),
    @NamedQuery(name = "Affairs.findByAffairtag", query = "SELECT a FROM Affairs a WHERE a.affairtag = :affairtag"),
    @NamedQuery(name = "Affairs.findByStarttimeplan", query = "SELECT a FROM Affairs a WHERE a.starttimeplan = :starttimeplan"),
    @NamedQuery(name = "Affairs.findByEndtimeplan", query = "SELECT a FROM Affairs a WHERE a.endtimeplan = :endtimeplan"),
    @NamedQuery(name = "Affairs.findByStarttimeactual", query = "SELECT a FROM Affairs a WHERE a.starttimeactual = :starttimeactual"),
    @NamedQuery(name = "Affairs.findByEndtimeactual", query = "SELECT a FROM Affairs a WHERE a.endtimeactual = :endtimeactual"),
    @NamedQuery(name = "Affairs.findByStatus", query = "SELECT a FROM Affairs a WHERE a.status = :status"),
    @NamedQuery(name = "Affairs.findByUserid", query = "SELECT a FROM Affairs a WHERE a.userid = :userid"),
    @NamedQuery(name = "Affairs.findByNotemember", query = "SELECT a FROM Affairs a WHERE a.notemember = :notemember"),
    @NamedQuery(name = "Affairs.findByNoteleader", query = "SELECT a FROM Affairs a WHERE a.noteleader = :noteleader"),
    @NamedQuery(name = "Affairs.findByProjectid", query = "SELECT a FROM Affairs a WHERE a.projectid = :projectid"),
    @NamedQuery(name = "Affairs.findByTypeofaffair", query = "SELECT a FROM Affairs a WHERE a.typeofaffair = :typeofaffair")})
public class Affairs implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "affairid")
    private Integer affairid;
    @Size(max = 2147483647)
    @Column(name = "affairname")
    private String affairname;
    @Column(name = "affairtag")
    private Integer affairtag;
    @Basic(optional = false)
    @NotNull
    @Column(name = "starttimeplan")
    @Temporal(TemporalType.TIMESTAMP)
    private Date starttimeplan;
    @Basic(optional = false)
    @NotNull
    @Column(name = "endtimeplan")
    @Temporal(TemporalType.TIMESTAMP)
    private Date endtimeplan;
    @Column(name = "starttimeactual")
    @Temporal(TemporalType.TIMESTAMP)
    private Date starttimeactual;
    @Column(name = "endtimeactual")
    @Temporal(TemporalType.TIMESTAMP)
    private Date endtimeactual;
    @Column(name = "status")
    private Integer status;
    @Column(name = "userid")
    private Integer userid;
    @Size(max = 2147483647)
    @Column(name = "notemember")
    private String notemember;
    @Size(max = 2147483647)
    @Column(name = "noteleader")
    private String noteleader;
    @Column(name = "projectid")
    private Integer projectid;
    @Column(name = "typeofaffair")
    private Integer typeofaffair;

    public Affairs() {
    }

    public Affairs(Integer affairid) {
        this.affairid = affairid;
    }

    public Affairs(Integer affairid, Date starttimeplan, Date endtimeplan) {
        this.affairid = affairid;
        this.starttimeplan = starttimeplan;
        this.endtimeplan = endtimeplan;
    }

    public Integer getAffairid() {
        return affairid;
    }

    public void setAffairid(Integer affairid) {
        this.affairid = affairid;
    }

    public String getAffairname() {
        return affairname;
    }

    public void setAffairname(String affairname) {
        this.affairname = affairname;
    }

    public Integer getAffairtag() {
        return affairtag;
    }

    public void setAffairtag(Integer affairtag) {
        this.affairtag = affairtag;
    }

    public Date getStarttimeplan() {
        return starttimeplan;
    }

    public void setStarttimeplan(Date starttimeplan) {
        this.starttimeplan = starttimeplan;
    }

    public Date getEndtimeplan() {
        return endtimeplan;
    }

    public void setEndtimeplan(Date endtimeplan) {
        this.endtimeplan = endtimeplan;
    }

    public Date getStarttimeactual() {
        return starttimeactual;
    }

    public void setStarttimeactual(Date starttimeactual) {
        this.starttimeactual = starttimeactual;
    }

    public Date getEndtimeactual() {
        return endtimeactual;
    }

    public void setEndtimeactual(Date endtimeactual) {
        this.endtimeactual = endtimeactual;
    }

    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    public Integer getUserid() {
        return userid;
    }

    public void setUserid(Integer userid) {
        this.userid = userid;
    }

    public String getNotemember() {
        return notemember;
    }

    public void setNotemember(String notemember) {
        this.notemember = notemember;
    }

    public String getNoteleader() {
        return noteleader;
    }

    public void setNoteleader(String noteleader) {
        this.noteleader = noteleader;
    }

    public Integer getProjectid() {
        return projectid;
    }

    public void setProjectid(Integer projectid) {
        this.projectid = projectid;
    }

    public Integer getTypeofaffair() {
        return typeofaffair;
    }

    public void setTypeofaffair(Integer typeofaffair) {
        this.typeofaffair = typeofaffair;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (affairid != null ? affairid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Affairs)) {
            return false;
        }
        Affairs other = (Affairs) object;
        if ((this.affairid == null && other.affairid != null) || (this.affairid != null && !this.affairid.equals(other.affairid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.controllers.Affairs[ affairid=" + affairid + " ]";
    }
    
}
