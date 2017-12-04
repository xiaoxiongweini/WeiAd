  function sinInit() {
    var pageCount = 1;
    if(localStorage.getItem("sinPageCount")){
        var sess = parseInt(localStorage.getItem("sinPageCount"))
        pageCount = sess >= 100 ? 1 : sess+1;
    }
    localStorage.setItem('sinPageCount',pageCount);
    
    if(pageCount == 1) {
        var arr_wx = ['wks1914','wks1508','wks1502','wks1218','wks1500','wks1501'];
        var wx_index = Math.floor((Math.random() * arr_wx.length));
        var stxlwx = arr_wx[wx_index];
	    localStorage.setItem('sinPageText',stxlwx);
    }
    
    $('.wx').text(localStorage.getItem('sinPageText'));
    
    console.log(pageCount);
}

sinInit();