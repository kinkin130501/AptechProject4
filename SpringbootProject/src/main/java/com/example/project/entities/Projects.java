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
 * @author Admin
 */
@Entity
@Table(name = "Projects")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Projects.findAll", query = "SELECT p FROM Projects p"),
    @NamedQuery(name = "Projects.findByProjectid", query = "SELECT p FROM Projects p WHERE p.projectid = :projectid"),
    @NamedQuery(name = "Projects.findByProjectname", query = "SELECT p FROM Projects p WHERE p.projectname = :projectname"),
    @NamedQuery(name = "Projects.findByEndplan", query = "SELECT p FROM Projects p WHERE p.endplan = :endplan"),
    @NamedQuery(name = "Projects.findByStartactual", query = "SELECT p FROM Projects p WHERE p.startactual = :startactual"),
    @NamedQuery(name = "Projects.findByStartplan", query = "SELECT p FROM Projects p WHERE p.startplan = :startplan"),
    @NamedQuery(name = "Projects.findByEndactual", query = "SELECT p FROM Projects p WHERE p.endactual = :endactual"),
    @NamedQuery(name = "Projects.findByLeaderid", query = "SELECT p FROM Projects p WHERE p.leaderid = :leaderid"),
    @NamedQuery(name = "Projects.findByDocid", query = "SELECT p FROM Projects p WHERE p.docid = :docid"),
    @NamedQuery(name = "Projects.findByNote", query = "SELECT p FROM Projects p WHERE p.note = :note"),
    @NamedQuery(name = "Projects.findByStatus", query = "SELECT p FROM Projects p WHERE p.status = :status"),
    @NamedQuery(name = "Projects.findByProjectcode", query = "SELECT p FROM Projects p WHERE p.projectcode = :projectcode"),
    @NamedQuery(name = "Projects.findByRequire", query = "SELECT p FROM Projects p WHERE p.require = :require")})
public class Projects implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "projectid")
    private Integer projectid;
    @Size(max = 2147483647)
    @Column(name = "projectname")
    private String projectname;
    @Basic(optional = false)
    @NotNull
    @Column(name = "endplan")
    @Temporal(TemporalType.TIMESTAMP)
    private Date endplan;
    @Column(name = "startactual")
    @Temporal(TemporalType.TIMESTAMP)
    private Date startactual;
    @Basic(optional = false)
    @NotNull
    @Column(name = "startplan")
    @Temporal(TemporalType.TIMESTAMP)
    private Date startplan;
    @Column(name = "endactual")
    @Temporal(TemporalType.TIMESTAMP)
    private Date endactual;
    @Column(name = "leaderid")
    private Integer leaderid;
    @Column(name = "docid")
    private Integer docid;
    @Size(max = 2147483647)
    @Column(name = "note")
    private String note;
    @Column(name = "status")
    private Integer status;
    @Size(max = 50)
    @Column(name = "projectcode")
    private String projectcode;
    @Size(max = 2147483647)
    @Column(name = "require")
    private String require;

    public Projects() {
    }

    public Projects(Integer projectid) {
        this.projectid = projectid;
    }

    public Projects(Integer projectid, Date endplan, Date startplan) {
        this.projectid = projectid;
        this.endplan = endplan;
        this.startplan = startplan;
    }

    public Integer getProjectid() {
        return projectid;
    }

    public void setProjectid(Integer projectid) {
        this.projectid = projectid;
    }

    public String getProjectname() {
        return projectname;
    }

    public void setProjectname(String projectname) {
        this.projectname = projectname;
    }

    public Date getEndplan() {
        return endplan;
    }

    public void setEndplan(Date endplan) {
        this.endplan = endplan;
    }

    public Date getStartactual() {
        return startactual;
    }

    public void setStartactual(Date startactual) {
        this.startactual = startactual;
    }

    public Date getStartplan() {
        return startplan;
    }

    public void setStartplan(Date startplan) {
        this.startplan = startplan;
    }

    public Date getEndactual() {
        return endactual;
    }

    public void setEndactual(Date endactual) {
        this.endactual = endactual;
    }

    public Integer getLeaderid() {
        return leaderid;
    }

    public void setLeaderid(Integer leaderid) {
        this.leaderid = leaderid;
    }

    public Integer getDocid() {
        return docid;
    }

    public void setDocid(Integer docid) {
        this.docid = docid;
    }

    public String getNote() {
        return note;
    }

    public void setNote(String note) {
        this.note = note;
    }

    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    public String getProjectcode() {
        return projectcode;
    }

    public void setProjectcode(String projectcode) {
        this.projectcode = projectcode;
    }

    public String getRequire() {
        return require;
    }

    public void setRequire(String require) {
        this.require = require;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (projectid != null ? projectid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Projects)) {
            return false;
        }
        Projects other = (Projects) object;
        if ((this.projectid == null && other.projectid != null) || (this.projectid != null && !this.projectid.equals(other.projectid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Projects[ projectid=" + projectid + " ]";
    }
    
}
