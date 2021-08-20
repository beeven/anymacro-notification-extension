using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace anymacro_notification_blazor
{
    public record CheckMailResponse
    {
        public string Result {get;set;}
        public string Model {get;set;}
        public string Cmd {get;set;}
        
        public MailData Data {get;set;}
        public string MXDirtim {get;set;}
        public MailFolder[] Folder {get;set;}
        public string MemcacheCurItems {get;set;}
    }

    public record MailData
    {
        public MailDataInfo Info {get;set;}

        public Dictionary<string, MailDataInfoBody> MailList;
    }

    public record MailFolder
    {
        public string DID {get;set;}
        public string DirName {get;set;}
        public string DirType {get;set;}
        public string MailNum {get;set;}
        public string NewMailNum {get;set;}
        public string Size {get;set;}
        public string Parent {get;set;}
    }

    public record MailDataInfo
    {
        [JsonPropertyName("curpage")]
        public int CurrentPage {get;set;}
        public int Pages {get;set;}
        public string MailNum {get;set;}

        public int NewMailNum {get;set;}
    }

    public record MailDataInfoBody
    {
        [JsonPropertyName("mid")]
        public string MailID {get;set;}

        public int Re {get;set;}

        public int Fw {get;set;}
        public int Readed {get;set;}
        public int Att {get;set;}

        [JsonPropertyName("subj")]
        public string Subject {get;set;}

        public string MDate {get;set;}

        public int MSize {get;set;}

        public string Mark {get;set;}

        public int Pr {get;set;}

        public int Flag {get;set;}

        public int POP3 {get;set;}
        public string MFrom {get;set;}
        public string From {get;set;}
        public string Body {get;set;}
        public string DID {get;set;}
        public int MJ {get;set;}
        public int SMJ {get;set;}
        public MailTo[] To {get;set;}
        public string Grid {get;set;}
        public string TGrid {get;set;}
        public int SendSrc {get;set;}
        public int SendStatus {get;set;}
        public int WithDraw {get;set;}
        public string Sign {get;set;}
    }

    public record MailTo {
        public string Name {get;set;}
        public string Email {get;set;}
    }
}