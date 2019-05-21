$(()=>{
    dropdownOptions.forEach(dp => {
        if(dp.isLinked){
            $(`#${dp.id}`).on('change',(e)=>{
                var target = e.target
                var selectedValue = $(target).val()
                loadData(dp.dataUrl, dp.linkedTo, dp.linkedToName, selectedValue, dp.linkedToIdName, dp.linkedToDisplayName)
            })
        }
    });

    function loadData(url,elementId,elementName,value, dataFieldName, displayFieldName){
        var option = `<option value=0>Select ${elementName}</option>`

        url = `${url}?id=${value}`

        $.ajax({
            url: url,
            success: (r)=>{
                r.forEach(data => {
                        option = option + `<option value=${data[`${dataFieldName}`]}>${data[`${displayFieldName}`]}</option>`
                });

                $(`#${elementId}`).html("")
                $(`#${elementId}`).html(option)
            },
            error: (e)=>{
                console.log(e)
            }
        })
    }
})
