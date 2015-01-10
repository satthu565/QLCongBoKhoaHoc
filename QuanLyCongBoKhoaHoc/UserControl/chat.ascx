<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="chat.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.chat" %>

    <div id="divContainer">
        <div id="divLogin" class="login">
            <div>
                Nhập tên của bạn:<br />
                <input id="txtNickName" type="text" class="textBox" />
            </div>
            <div id="divButton">
                <input id="btnStartChat" type="button" class="submitButton" value="Start Chat" />
            </div>
        </div>

        <div id="divChat" class="chatRoom">
            <!--<div class="title">
                Welcome to Chat Room [<span id='spanUser'></span>]

            </div>-->
            <div class="content">
                <div id="divChatWindow" class="chatWindow">
                </div>
                
                <div id="divusers" class="users">
                </div>
            </div>
            <div class="messageBar">
                <input class="textbox" type="text" id="txtMessage" />
                <input id="btnSendMsg" type="button" value="Send" class="submitButton" />
            </div>
        </div>

        <input id="hdId" type="hidden" />
        <input id="hdUserName" type="hidden" />
    </div>
