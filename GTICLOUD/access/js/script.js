 $(document).ready(function(){

     $('select').formSelect();
     $(".dropdown-trigger").dropdown();

   /* $("a#accessCtrl.waves-effect.waves-light.btn").click(function () {

         var skey = $(this).attr('skey');

        // alert(skey + "");

         sessionStorage.setItem("skay", skey);
       

         window.location.replace("AccessControl.aspx");

    });

    $("#getSession").val(sessionStorage.getItem("skay"));*/
   
     $(".authbtn").click(function () {

         var id = $(this).attr("uid");
         var skey = $(this).attr("skey");

         // alert(id + " " + skey);
         // location.reload(true);

         $.ajax({
             url: "UpdateAuth.aspx",
             type: "get", //send it through get method
             data: {
                 id: id,
                 sitekey: skey,
                 
             },
             success: function (response) {
                 location.reload(true);
             },
             error: function (xhr) {
                 alert('error');
             }
         });
     });
     
     
  });
