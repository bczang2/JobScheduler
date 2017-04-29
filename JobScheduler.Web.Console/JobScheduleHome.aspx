<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobScheduleHome.aspx.cs" Inherits="JobScheduler.JobScheduleHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            font-size: 62.5%;
        }

        input.text, textarea {
            margin-bottom: 12px;
            width: 95%;
            padding: .4em;
        }

        textarea {
            height: 200px;
        }

        fieldset {
            padding: 0;
            border: 0;
            margin-top: 25px;
        }

        h1 {
            font-size: 1.2em;
            margin: .6em 0;
        }

        div#users-contain {
            width: 350px;
            margin: 20px 0;
        }

            div#users-contain table {
                margin: 1em 0;
                border-collapse: collapse;
                width: 100%;
            }

                div#users-contain table td, div#users-contain table th {
                    border: 1px solid #eee;
                    padding: .6em 10px;
                    text-align: left;
                }

        .ui-dialog .ui-state-error {
            padding: .3em;
        }

        .validateTips {
            border: 1px solid transparent;
            padding: 0.3em;
        }

        input[type=submit] {
            height: 30px;
            width: 64px;
            border-radius: 4px;
        }

        #startdatepicker, #enddatepicker {
            width: 204px;
            height: 24px;
        }

        #date {
            margin-bottom: 12px;
            width: 95%;
            padding: .4em;
            border: solid darkgray 0.5px;
            border-radius: 4px;
            margin-left: 20px;
        }
    </style>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css" />
    <script>
        $(function () {
            $("#tabs").tabs();

            $("#startdatepicker").datepicker({
                showOtherMonths: true,
                selectOtherMonths: true
            });

            $("#enddatepicker").datepicker({
                showOtherMonths: true,
                selectOtherMonths: true
            });

            $("#startdatepicker").datepicker("option", "dateFormat", "yy-mm-dd");

            $("#enddatepicker").datepicker("option", "dateFormat", "yy-mm-dd");

            $("#baseInfo").draggable();
        });

        function msgAlert(msg) {
            $('#msg').text(msg);
            $("#dialog-modal").dialog({
                height: 140,
                modal: true
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin: 20px auto; width: 1000px; height: auto; border: solid darkgray 1px">
            <div>
                <h3 style="width: 1000px; height: 40px; background-color: darkgray; margin: 0 auto; padding-top: 20px;">Job Schedule DashBorad</h3>
            </div>
            <div id="users-contain" class="ui-widget">
                <table id="baseInfo" class="ui-widget ui-widget-content" style="margin-left: 50px; width: 600px;">
                    <tbody>
                        <tr>
                            <td rowspan="8">基本信息</td>
                        </tr>
                        <tr>
                            <td>Name:</td>
                            <td><span runat="server" id="scheduleName"></span></td>
                        </tr>
                        <tr>
                            <td>Scheduler Running Status:</td>
                            <td><span runat="server" id="scheduleRunStatus"></span></td>
                        </tr>
                        <tr>
                            <td>Running since:</td>
                            <td><span runat="server" id="scheduleRunSTime"></span></td>
                        </tr>
                        <tr>
                            <td>Instance ID:</td>
                            <td><span runat="server" id="scheduleInstance"></span></td>
                        </tr>
                        <tr>
                            <td>TotalJobCount:</td>
                            <td><span runat="server" id="jobCount"></span></td>
                        </tr>
                        <tr>
                            <td>ThreadPool Size:</td>
                            <td><span runat="server" id="threadSize"></span></td>
                        </tr>
                        <tr>
                            <td>Version:</td>
                            <td><span runat="server" id="version"></span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div id="tabs">
                <ul>
                    <li><a href="#tabs-1">新增job</a></li>
                    <li><a href="#tabs-2">暂停job</a></li>
                    <li><a href="#tabs-3">删除job</a></li>
                    <li><a href="#tabs-4">恢复job</a></li>
                </ul>
                <div id="tabs-1">
                    <fieldset>
                        <label for="name">JobName：</label>
                        <input type="text" name="jobName" id="jobName" runat="server" class="text ui-widget-content ui-corner-all" />
                        <label for="email">JobGroup：</label>
                        <input type="text" name="jobGroup" id="jobGroup" runat="server" value="" class="text ui-widget-content ui-corner-all" />
                        <label for="email">JobCron：</label>
                        <input type="text" name="jobGroup" id="jobCron" runat="server" value="" class="text ui-widget-content ui-corner-all" />
                        <label for="password">Date：</label>
                        <p id="date">开始日期：<input type="text" id="startdatepicker" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;结束日期：<input type="text" id="enddatepicker" runat="server" /></p>
                        <label for="email">JobDesc：</label>
                        <input type="text" name="jobGroup" id="jobDesc" runat="server" value="" class="text ui-widget-content ui-corner-all" />
                        <label for="password">JobData：</label>
                        <textarea class="text ui-widget-content ui-corner-all " id="jobData" runat="server">
                        </textarea>
                    </fieldset>
                    <input type="submit" value="Add" onserverclick="AddJob_ServerClick" runat="server" />
                </div>
                <div id="tabs-2">
                    <fieldset>
                        <label for="name">JobName：</label>
                        <input type="text" name="jobName" id="pauseJobName" runat="server" class="text ui-widget-content ui-corner-all" />
                        <label for="email">JobGroup：</label>
                        <input type="text" name="jobGroup" id="pauseJobGroup" runat="server" value="" class="text ui-widget-content ui-corner-all" />
                    </fieldset>
                    <input type="submit" value="Pause" runat="server" onserverclick="PauseJob_ServerClick" />
                </div>
                <div id="tabs-3">
                    <fieldset>
                        <label for="name">JobName：</label>
                        <input type="text" name="jobName" id="delJobName" runat="server" class="text ui-widget-content ui-corner-all" />
                        <label for="email">JobGroup：</label>
                        <input type="text" name="jobGroup" id="delJobGroup" runat="server" value="" class="text ui-widget-content ui-corner-all" />
                    </fieldset>
                    <input type="submit" value="Delete" runat="server" onserverclick="DeletedJob_ServerClick" />
                </div>
                <div id="tabs-4">
                    <fieldset>
                        <label for="name">JobName：</label>
                        <input type="text" name="jobName" id="resumeJobName" runat="server" class="text ui-widget-content ui-corner-all" />
                        <label for="email">JobGroup：</label>
                        <input type="text" name="jobGroup" id="resumeJobGroup" runat="server" value="" class="text ui-widget-content ui-corner-all" />
                    </fieldset>
                    <input type="submit" value="Resume" runat="server" onserverclick="ResumeJob_ServerClick" />
                </div>
            </div>
        </div>
        <div id="dialog-modal" title="Tips">
            <p id="msg"></p>
        </div>
    </form>
</body>
</html>
