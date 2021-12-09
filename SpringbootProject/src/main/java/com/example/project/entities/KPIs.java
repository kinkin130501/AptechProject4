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
 * @author vuman
 */
@Entity
@Table(name = "KPIs")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "KPIs.findAll", query = "SELECT k FROM KPIs k"),
    @NamedQuery(name = "KPIs.findByKpiid", query = "SELECT k FROM KPIs k WHERE k.kpiid = :kpiid"),
    @NamedQuery(name = "KPIs.findByMembername", query = "SELECT k FROM KPIs k WHERE k.membername = :membername"),
    @NamedQuery(name = "KPIs.findByWorktime", query = "SELECT k FROM KPIs k WHERE k.worktime = :worktime"),
    @NamedQuery(name = "KPIs.findByProjectdone", query = "SELECT k FROM KPIs k WHERE k.projectdone = :projectdone")})
public class KPIs implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "kpiid")
    private Integer kpiid;
    @Size(max = 2147483647)
    @Column(name = "membername")
    private String membername;
    @Size(max = 2147483647)
    @Column(name = "worktime")
    private String worktime;
    @Size(max = 2147483647)
    @Column(name = "projectdone")
    private String projectdone;

    public KPIs() {
    }

    public KPIs(Integer kpiid) {
        this.kpiid = kpiid;
    }

    public Integer getKpiid() {
        return kpiid;
    }

    public void setKpiid(Integer kpiid) {
        this.kpiid = kpiid;
    }

    public String getMembername() {
        return membername;
    }

    public void setMembername(String membername) {
        this.membername = membername;
    }

    public String getWorktime() {
        return worktime;
    }

    public void setWorktime(String worktime) {
        this.worktime = worktime;
    }

    public String getProjectdone() {
        return projectdone;
    }

    public void setProjectdone(String projectdone) {
        this.projectdone = projectdone;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (kpiid != null ? kpiid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof KPIs)) {
            return false;
        }
        KPIs other = (KPIs) object;
        if ((this.kpiid == null && other.kpiid != null) || (this.kpiid != null && !this.kpiid.equals(other.kpiid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.KPIs[ kpiid=" + kpiid + " ]";
    }
    
}
