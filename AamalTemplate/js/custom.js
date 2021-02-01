(function($){

//Add Hover effect to menus
jQuery('li').hover(function() {
  jQuery(this).find('> .dropdown-menu').stop(true, true).delay(100).fadeIn();
}, function() {
  jQuery(this).find('> .dropdown-menu').stop(true, true).delay(500).fadeOut();
});
$('.follow a').tooltip();
jQuery('.topbar').affix({
		offset: { top: $('.topbar').offset().top }
	});
	
// Back to Top
 jQuery(window).scroll(function(){
	if (jQuery(this).scrollTop() > 1) {
			jQuery('.gototop').css({bottom:"25px"});
		} else {
			jQuery('.gototop').css({bottom:"-100px"});
		}
	});
	jQuery('.gototop').click(function(){
		jQuery('html, body').animate({scrollTop: '0px'}, 800);
		return false;
});
$('.chart').easyPieChart({
				easing: 'easeOutBounce',
				size : 120,
				animate : 2000,
				lineCap : 'square',
				lineWidth : 15,
				barColor : false,
				trackColor : '#F5F5F5',
				scaleColor : false,
				onStep: function(from, to, percent) {
				$(this.el).find('.percent').text(Math.round(percent)+'%');
				}
			});

})(jQuery);