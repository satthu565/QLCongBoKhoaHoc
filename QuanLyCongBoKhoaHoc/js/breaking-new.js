

jQuery(document).ready(function() {
	jQuery("body").append("<a href='#top' class='backtopbutton'><span class='icon-text'><i class='fa fa-angle-up'></i></span></a>");

	jQuery("a[href='#top']").click(function() {
		jQuery("html, body").animate({ scrollTop: 0 }, "slow");
		return false;
	});

	jQuery("a[href=#top]").click(function(){
		jQuery("html, body").animate({ scrollTop: 0 }, "normal");
		return false;
	});

	start();
	// Breaking News Scroller
	jQuery(".breaking-news .breaking-block").each(function() {
		var thisitem = jQuery(this);
		thisitem.find("ul li").css("width", thisitem.width()+"px");
	});

	jQuery(".breaking-controls a").click(function() {
		var thisitem = jQuery(this);
		var itemul = thisitem.parent().parent().find(".breaking-block ul");
		var items = itemul.find("li");
		var sega = (items.size()-1)*(items.width()+parseInt(items.css("margin-right")));
		if(thisitem.hasClass("breaking-arrow-left")){
			if(0 >= Math.abs(parseInt(itemul.css("margin-left")))){
				itemul.css("margin-left", (sega*(-1))+"px");

			}else{
				itemul.css("margin-left", (parseInt(itemul.css("margin-left"))+(items.width()+parseInt(items.css("margin-right"))))+"px");

			}
		}else{
			if(sega <= Math.abs(parseInt(itemul.css("margin-left")))){
				itemul.css("margin-left", "0px");
			}else{
				itemul.css("margin-left", (parseInt(itemul.css("margin-left"))+(items.width()+parseInt(items.css("margin-right")))*(-1))+"px");
			}
		}
		return false;
	});


	

	$(".breaking-news").mouseenter(function() {
		thisindex = jQuery(this).attr("rel");
		clearTimeout(elementsActive[thisindex]);
	}).mouseleave(function() {
		thisindex = jQuery(this).attr("rel");
		elementsActive[thisindex] = false;
	});
	
});

function start() {
	z = 0;
	jQuery('.breaking-block ul').each(function(){
		var thisitem = jQuery(this);
		var thisindex = z;
		z++;
		if(thisitem.find("li").size() > 0){

			if(!breakingStart)return false;
			var theBreakingMargin = parseInt(thisitem.find("li").css("margin-right"));

			var theBreakingWidth = parseInt(thisitem.parent().css("width"));
			theCount[thisindex] = ((Math.ceil(thisitem.find("li").size())/2)*(theBreakingWidth+theBreakingMargin));

			if(elementsToClone[thisindex]){
				jQuery(this).parent().parent().addClass("isscrolling");
				jQuery('.breaking-block').eq(thisindex).parent().attr("rel", thisindex);
				thisitem.find("li").clone().appendTo(this);

				elementsToClone[thisindex] = false;
			}
			var theNumber = theCount[thisindex]+breakingOffset[thisindex];

			if(Math.abs(theNumber) <= (Math.abs(breakingScroll[thisindex]))){
				cloneBreakingLine(thisindex);
			}
			
			if(!elementsActive[thisindex]){
				elementsActive[thisindex] = setInterval(function() {
					beginScrolling(thisitem, thisindex);
				}, breakingSpeed);
			}
		}
	});

	setTimeout("start()", breakingSpeed);
}

function beginScrolling(thisitem, thisindex){
	breakingScroll[thisindex] = breakingScroll[thisindex]-1;
	thisitem.css("left", breakingScroll[thisindex]+'px');
}

function cloneBreakingLine(thisindex){
	breakingScroll[thisindex] = 0;
	console.log(thisindex);
	jQuery('.breaking-block').eq(thisindex).find('ul').css("left", "0px");
}

