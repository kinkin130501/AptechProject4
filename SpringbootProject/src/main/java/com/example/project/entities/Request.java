/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import java.math.BigDecimal;
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
@Table(name = "Request")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Request.findAll", query = "SELECT r FROM Request r"),
    @NamedQuery(name = "Request.findByRequestid", query = "SELECT r FROM Request r WHERE r.requestid = :requestid"),
    @NamedQuery(name = "Request.findByRequestname", query = "SELECT r FROM Request r WHERE r.requestname = :requestname"),
    @NamedQuery(name = "Request.findByContent", query = "SELECT r FROM Request r WHERE r.content = :content"),
    @NamedQuery(name = "Request.findByReceiverid", query = "SELECT r FROM Request r WHERE r.receiverid = :receiverid"),
    @NamedQuery(name = "Request.findBySentdate", query = "SELECT r FROM Request r WHERE r.sentdate = :sentdate"),
    @NamedQuery(name = "Request.findByMoretime", query = "SELECT r FROM Request r WHERE r.moretime = :moretime"),
    @NamedQuery(name = "Request.findByStatus", query = "SELECT r FROM Request r WHERE r.status = :status"),
    @NamedQuery(name = "Request.findByResponecontent", query = "SELECT r FROM Request r WHERE r.responecontent = :responecontent"),
    @NamedQuery(name = "Request.findByReply", query = "SELECT r FROM Request r WHERE r.reply = :reply"),
    @NamedQuery(name = "Request.findByTaskid", query = "SELECT r FROM Request r WHERE r.taskid = :taskid"),
    @NamedQuery(name = "Request.findByRequestmoney", query = "SELECT r FROM Request r WHERE r.requestmoney = :requestmoney"),
    @NamedQuery(name = "Request.findByTotaltime", query = "SELECT r FROM Request r WHERE r.totaltime = :totaltime")})
public class Request implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "requestid")
    private Integer requestid;
    @Size(max = 2147483647)
    @Column(name = "requestname")
    private String requestname;
    @Size(max = 2147483647)
    @Column(name = "content")
    private String content;
    @Basic(optional = false)
    @NotNull
    @Column(name = "userid")
    private Integer userid;
    @NotNull
    @Column(name = "receiverid")
    private int receiverid;
    @Basic(optional = false)
    @NotNull
    @Column(name = "sentdate")
    @Temporal(TemporalType.TIMESTAMP)
    private Date sentdate;
    @Column(name = "moretime")
    @Temporal(TemporalType.TIMESTAMP)
    private Date moretime;
    @Basic(optional = false)
    @NotNull
    @Column(name = "status")
    private int status;
    @Size(max = 2147483647)
    @Column(name = "responecontent")
    private String responecontent;
    @Basic(optional = false)
    @NotNull
    @Column(name = "reply")
    private boolean reply;
    @Column(name = "taskid")
    private Integer taskid;
    @Column(name = "requestmoney")
    private Long requestmoney;
    @Column(name = "totaltime")
    private Long totaltime;

    public Request() {
    }

    public Request(Integer requestid) {
        this.requestid = requestid;
    }

    public Request(Integer requestid, int receiverid, Date sentdate, int status, boolean reply) {
        this.requestid = requestid;
        this.receiverid = receiverid;
        this.sentdate = sentdate;
        this.status = status;
        this.reply = reply;
    }

    public Integer getRequestid() {
        return requestid;
    }

    public void setRequestid(Integer requestid) {
        this.requestid = requestid;
    }

    public String getRequestname() {
        return requestname;
    }

    public void setRequestname(String requestname) {
        this.requestname = requestname;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }
    
    public int getUserid() {
        return userid;
    }

    public void setUserid(int userid) {
        this.userid = userid;
    }

    public int getReceiverid() {
        return receiverid;
    }

    public void setReceiverid(int receiverid) {
        this.receiverid = receiverid;
    }

    public Date getSentdate() {
        return sentdate;
    }

    public void setSentdate(Date sentdate) {
        this.sentdate = sentdate;
    }

    public Date getMoretime() {
        return moretime;
    }

    public void setMoretime(Date moretime) {
        this.moretime = moretime;
    }

    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
    }

    public String getResponecontent() {
        return responecontent;
    }
public void setResponecontent(String responecontent) {
        this.responecontent = responecontent;
    }

    public boolean getReply() {
        return reply;
    }

    public void setReply(boolean reply) {
        this.reply = reply;
    }

    public Integer getTaskid() {
        return taskid;
    }

    public void setTaskid(Integer taskid) {
        this.taskid = taskid;
    }

    public Long getRequestmoney() {
        return requestmoney;
    }

    public void setRequestmoney(Long requestmoney) {
        this.requestmoney = requestmoney;
    }

    public Long getTotaltime() {
        return totaltime;
    }

    public void setTotaltime(Long totaltime) {
        this.totaltime = totaltime;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (requestid != null ? requestid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Request)) {
            return false;
        }
        Request other = (Request) object;
        if ((this.requestid == null && other.requestid != null) || (this.requestid != null && !this.requestid.equals(other.requestid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Request[ requestid=" + requestid + " ]";
    }
    
}
