//$(document).ready(function () {
    //$(".bluev2").click(function(){
       // $(".alo:nth-child(1)").removeClass("animacao");
      //  $(".alo:nth-child(1)").addClass("animacao2");
       // $(".alo:nth-child(1)").addClass("animacao");
   // }); 
//});


$(document).ready(function () {
    $(".bluev2").click(function(){
        $(".alo").each(function (i) {
            $(".alo").eq(0).removeClass("animacao");
            $(".alo").eq(0).addClass("animacao2");
            $(".alo").eq(1).addClass("animacao");
        
        });
        
       
    });
    
});