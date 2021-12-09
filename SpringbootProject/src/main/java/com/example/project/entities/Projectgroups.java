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
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author vuchu
 */
@Entity
@Table(name = "Projectgroups")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Projectgroups.findAll", query = "SELECT p FROM Projectgroups p"),
    @NamedQuery(name = "Projectgroups.findByProjectid", query = "SELECT p FROM Projectgroups p WHERE p.projectid = :projectid"),
    @NamedQuery(name = "Projectgroups.findByGroupid", query = "SELECT p FROM Projectgroups p WHERE p.groupid = :groupid")})
public class Projectgroups implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "projectid")
    private Integer projectid;
    @Column(name = "groupid")
    private Integer groupid;

    public Projectgroups() {
    }

    public Projectgroups(Integer projectid) {
        this.projectid = projectid;
    }

    public Integer getProjectid() {
        return projectid;
    }

    public void setProjectid(Integer projectid) {
        this.projectid = projectid;
    }

    public Integer getGroupid() {
        return groupid;
    }

    public void setGroupid(Integer groupid) {
        this.groupid = groupid;
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
        if (!(object instanceof Projectgroups)) {
            return false;
        }
        Projectgroups other = (Projectgroups) object;
        if ((this.projectid == null && other.projectid != null) || (this.projectid != null && !this.projectid.equals(other.projectid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Projectgroups[ projectid=" + projectid + " ]";
    }
    
}
