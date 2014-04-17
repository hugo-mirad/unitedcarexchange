<%@ Page Language="C#" AutoEventWireup="true" CodeFile="production2.aspx.cs" Inherits="production2"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/production.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script src="js/production.js" type="text/javascript"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script type="text/javascript">
        var CarID1;
        function pageLoad() {
        //var path1 = "http://localhost:4111/Cars/2011/Alfa Romeo/8C Competizione/Index.aspx"
        GetRecentListings();
       $.extend({
        getUrlVars: function(){
          var vars = [], hash;
          var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
          for(var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
          }
          return vars;
        },
        getUrlVar: function(name){
          return $.getUrlVars()[name];
        }
      });
      
      
        var urlVars = $.getUrlVars();
        //alert(urlVars["C"]);      
        
        if(urlVars != null && urlVars != undefined && urlVars != '' && urlVars["C"] != undefined && urlVars["C"] != 'undefined' && urlVars["C"] != null && urlVars["C"] != ''){        
            
            var valid = true; 
            if(urlVars["C"]){     
                CarID1 = urlVars["C"];
            }else{
                valid = false;
            }       
           
            if(CarID1.length >= 1 && valid == true){          
                productionFindCarID(CarID1);
            }else{
                alert('Enter valid Car ID..!')
            }
               
            //alert(CarID1);
                  
            //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');            
            //alert(WithinZip1);      
            
        }else{
             // window.location.href='searchcars.aspx?Make=All makes&Model=All models&ZipCode=92404&WithinZip=4';
              alert('Enter valid Car ID..!')
        }       
        
    }
    </script>

    <!-- Look at the configuration -->
</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                </div>
                <!-- content -->
                <div id="content" style="background: #fff;">
                    <table style="width: 900px; margin: 0 auto; padding: 50px 0 0 0;">
                        <tr style="display: none">
                            <td style="padding-bottom: 20px;" id="searchFormHolder">
                                <strong style="width: 65px; display: inline-block; font-size: 14px;">Car ID:</strong>
                                <input type="text" class="txtCarID" style="padding: 5px; font-size: 13px; border: #ccc 1px solid;
                                    margin-right: 5px;" maxlength="6" />
                                <input type="button" value="Search" class="button1 search" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td style="height: 10px; border-top: #666 2px dashed;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="proDet">
                                    <div class="detailsDiv">
                                        <h3 class="Title">
                                        </h3>
                                        <strong>Car ID: </strong>
                                        <label class="carID">
                                        </label>
                                        <br />
                                        <strong>Name: </strong>
                                        <label class="name">
                                        </label>
                                        <br />
                                        <strong>Email: </strong>
                                        <label class="email">
                                        </label>
                                        <br />
                                        <strong>City & State: </strong>
                                        <label class="city">
                                        </label>
                                        <br />
                                        <strong>Phone: </strong>
                                        <label class="phone">
                                        </label>
                                        <br />
                                        <strong>UCE URL: </strong>
                                        <textarea class="url" style="background: #fff; border: #ccc 1px solid; padding: 5px;
                                            width: 750px; margin: 3px 0 0 0;"></textarea>
                                        <br />
                                        <a href="#" class="link1" style="display: none;">copy</a>
                                        <br />
                                        <div class="disc" style="width: 100%;">
                                        </div>
                                        <div class="SellerNotes">
                                        </div>
                                        <div class="imgHolder" style="">
                                            <ul>
                                            </ul>
                                            <div class="clear">
                                                &nbsp;</div>
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- footer -->
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Processing
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>
</body>
</html>
