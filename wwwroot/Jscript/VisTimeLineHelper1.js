function ready(fn) {
    if (document.readyState != 'loading') {
        fn();
    }
    else {
        document.addEventListener('DOMContentLoaded', fn);
    }
}

function setPageLanguage() {
    var lang = window.location.href.match(/&lang=([a-zA-Z]*?)&?/);

    if (lang) {
        document.getElementsByTagName('html')[0].setAttribute('lang', lang[1]);
    }

}

function computeEmbedPath()
{
    var trim_point = window.location.href.indexOf('embed/index.html');
    if (trim_point > 0)
    {
        // supports https access via https://s3.amazonaws.com/cdn.knightlab.com/libs/timeline/latest/embed/index.html
        return window.location.href.substring(0, trim_point);
    }
    return "https://cdn.knightlab.com/libs/timeline3/latest/";
}

function addOembedTag()
{
    // it's not clear that any tools execute this JS to get the URL, but maybe?
    var oembed_link = document.createElement('link');
    oembed_link['rel'] = 'alternate';
    oembed_link['type'] = 'application/json+oembed';
    oembed_link['href'] = 'https://oembed.knightlab.com/timeline/?url=' + encodeURIComponent(window.location.href);
    document.head.appendChild(oembed_link);
}

function createEmbedDiv(containerId, width, height)
{
    if (typeof (width) != 'string' && typeof (width) != 'number')
    {
        width = '100%'
    }

    if (typeof (height) != 'string' && typeof (height) != 'number')
    {
        height = '100%'
    }

    // default containerId would be 'timeline-embed'
    t = document.createElement('div');
    t.style.position = 'relative';

    te = document.getElementById(containerId);
    te.appendChild(t);
    te.classList.add("tl-timeline-embed");

    if (width.toString().match("%"))
    {
        te.style.width = width.split("%")[0] + "%";
    }
    else
    {
        width = Number(width) - 2;
        te.style.width = (width) + 'px';
    }

    if (height.toString().match("%"))
    {
        te.style.height = height;
        te.classList.add("tl-timeline-full-embed");
    }
    else
        if (width.toString().match("%"))
        {
            te.classList.add("tl-timeline-full-embed");
            height = Number(height) - 16;
            te.style.height = (height) + 'px';
        }
        else
        {
            height = height - 16;
            te.style.height = (height) + 'px';
        }
}

/**
 * Parse all URL parameters as possible Timeline options.
 * Timeline itself will use or ignore these based on actual
 * supported options.
 */
function optionsFromUrlParams()
{
    var param_str = window.location.href.slice(window.location.href.indexOf('?') + 1);

    if (param_str.match('#'))
    {
        param_str = param_str.split('#')[0];
    }

    param_str = param_str.split('&');

    var url_vars = {}

    for (var i = 0; i < param_str.length; i++)
    {
        var uv = param_str[i].split('=');
        url_vars[uv[0]] = uv[1];
    }

    return url_vars;
};

var dataObject =
{
    "title": {
        "media": {
            "url": "//www.flickr.com/photos/tm_10001/2310475988/",
            "caption": "Whitney Houston performing on her My Love is Your Love Tour in Hamburg.",
            "credit": "flickr/<a href='http://www.flickr.com/photos/tm_10001/'>tm_10001</a>"
        },
        "text": {
            "headline": "Whitney Houston<br/> 1963 - 2012",
            "text": "<p>Houston's voice caught the imagination of the world propelling her to superstardom at an early age becoming one of the most awarded performers of our time. This is a look into the amazing heights she achieved and her personal struggles with substance abuse and a tumultuous marriage.</p>"
        }
    },
    "events": [
        {
            "media":
            {
                "url": "{{ static_url }}/img/examples/houston/family.jpg",
                "caption": "Houston's mother and Gospel singer, Cissy Houston (left) and cousin Dionne Warwick.",
                "credit": "Cissy Houston photo:<a href='http://www.flickr.com/photos/11447043@N00/418180903/'>Tom Marcello</a><br/><a href='http://commons.wikimedia.org/wiki/File%3ADionne_Warwick_television_special_1969.JPG'>Dionne Warwick: CBS Television via Wikimedia Commons</a>"
            },
            "start_date":
            {
                "month": "8",
                "day": "9",
                "year": "1963"
            },
            "text":
            {
                "headline": "A Musical Heritage",
                "text": "<p>Born in New Jersey on August 9th, 1963, Houston grew up surrounded by the music business. Her mother is gospel singer Cissy Houston and her cousins are Dee Dee and Dionne Warwick.</p>"
            }
        },
        {
            "media":
            {
                "url": "https://youtu.be/fSrO91XO1Ck",
                "caption": "",
                "credit": "<a href=\"http://unidiscmusic.com\">Unidisc Music</a>"
            },
            "start_date":
            {
                "year": "1978"
            },
            "text":
            {
                "headline": "First Recording",
                "text": "At the age of 15 Houston was featured on Michael Zager's song, Life's a Party."
            }
        },
        {
            "media":
            {
                "url": "https://youtu.be/_gvJCCZzmro",
                "caption": "A young poised Whitney Houston in an interview with EbonyJet.",
                "credit": "EbonyJet"
            },
            "start_date":
            {
                "year": "1978"
            },
            "text":
            {
                "headline": "The Early Years",
                "text": "As a teen Houston's credits include background vocals for Jermaine Jackson, Lou Rawls and the Neville Brothers. She also sang on Chaka Khan's, 'I'm Every Woman,' a song which she later remade for the <i>Bodyguard</i> soundtrack which is the biggest selling soundtrack of all time. It sold over 42 million copies worldwide."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/H7_sqdkaAfo",
                "caption": "I'm Every Women as performed by Whitney Houston.",
                "credit": "Arista Records"
            },
            "start_date": {
                "year": "1978"
            },
            "text": {
                "headline": "Early Album Credits",
                "text": "As a teen Houston's credits include background vocals for Jermaine Jackson, Lou Rawls and the Neville Brothers. She also sang on Chaka Khan's, 'I'm Every Woman,' a song which she later remade for the <i>Bodyguard</i> soundtrack which is the biggest selling soundtrack of all time. It sold over 42 million copies worldwide."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/A4jGzNm2yPI",
                "caption": "Whitney Houston and Clive Davis discussing her discovery and her eponymous first album.",
                "credit": "Sony Music Entertainment"
            },
            "start_date": {
                "year": "1983"
            },
            "text": {
                "headline": "Signed",
                "text": "Houston is signed to Arista Records after exec Clive Davis sees her performing on stage with her mother in New York."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/m3-hY-hlhBg",
                "caption": "The 'How Will I Know' video showcases the youthful energy that boosted Houston to stardom.",
                "credit": "Arista Records Inc."
            },
            "start_date": {
                "year": "1985"
            },
            "text": {
                "headline": "Debut",
                "text": "Whitney Houston's self titled first release sold over 12 million copies in the U.S. and included the hit singles 'How Will I Know,' 'You Give Good Love,' 'Saving All My Love For You' and 'Greatest Love of All.'"
            }
        },
        {
            "media": {
                "url": "https://youtu.be/v0XuiMX1XHg",
                "caption": "Dionne Warwick gleefully announces cousin, Whitney Houston, the winner of the Best Female Pop Vocal Performance for the song Saving All My Love.",
                "credit": "<a href='http://grammy.org'>The Recording Academy</a>"
            },
            "start_date": {
                "year": "1986"
            },
            "text": {
                "headline": "'The Grammys'",
                "text": "In 1986 Houston won her first Grammy for the song Saving All My Love. In total she has won six Grammys, the last of which she won in 1999 for It's Not Right But It's Okay."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/eH3giaIzONA",
                "caption": "I Wanna Dance With Somebody",
                "credit": "Arista Records Inc."
            },
            "start_date": {
                "year": "1987"
            },
            "text": {
                "headline": "'Whitney'",
                "text": "Multiplatinum second album sells more than 20 million copies worldwide. With 'Whitney', Houston became the first female artist to produce four number 1 singles on one album including \"I Wanna Dance With Somebody,' 'Didn't We Almost Have It All,' 'So Emotional' and 'Where Do Broken Hearts Go.'"
            }
        },
        {
            "media": {
                "url": "https://youtu.be/96aAx0kxVSA",
                "caption": "\"One Moment In Time\" - Theme song to the 1988 Seoul Olympics",
                "credit": "Arista Records Inc."
            },
            "start_date": {
                "year": "1988"
            },
            "text": {
                "headline": "\"One Moment In Time\"",
                "text": "The artist's fame continues to skyrocket as she records the theme song for the Seoul Olympics, 'One Moment In Time.'"
            }
        },
        {
            "media": {
                "url": "",
                "caption": "",
                "credit": ""
            },
            "start_date": {
                "year": "1989"
            },
            "text": {
                "headline": "Bobby Brown",
                "text": "Houston and Brown first meet at the Soul Train Music Awards. In an interview with Rolling Stone Magazine, Houston admitted that it was not love at first sight. She turned down Brown's first marriage proposal but eventually fell in love with him."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/5Fa09teeaqs",
                "caption": "CNN looks back at Houston's iconic performance of the national anthem at Superbowl XXV.",
                "credit": "CNN"
            },
            "start_date": {
                "year": "1991"
            },
            "text": {
                "headline": "Super Bowl",
                "text": "Houston's national anthem performance captures the hearts and minds of Americans ralllying behind soldiers in the Persian Guf War."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/h9rCobRl-ng",
                "caption": "\"Run To You\" from the 1992 \"Bodyguard\" soundtrack..",
                "credit": "Arista Records"
            },
            "start_date": {
                "year": "1992"
            },
            "text": {
                "headline": "\"The Bodyguard\"",
                "text": "Houston starred opposite Kevin Costner in the box office hit, The Bodyguard. The soundtrack to the movie sold over 44 million copies worldwide  garnering 3 Grammy's for the artist."
            }
        },
        {
            "media": {
                "url": "https://youtu.be/5cDLZqe735k",
                "caption": "Bobby Brown performing \"My Prerogrative,\" from his \"Don't be Cruel\" solo album. Bobby Brown first became famous with the R&B group, New Edition.",
                "credit": ""
            },
            "start_date": {
                "year": "1992"
            },
            "text": {
                "headline": "Married Life",
                "text": "<p>After three years of courtship, Houston marries New Edition singer Bobby Brown. Their only child Bobbi Kristina Brown was born in 1993.</p><p>In 2003 Brown was charged with domestic violence after police responded to a domestic violence call. Houston and Brown were featured in the reality show, \"Being bobby Brown,\" and divorced in 2007.</p>"
            }
        },
        {
            "media": {
                "url": "//upload.wikimedia.org/wikipedia/commons/d/dd/ABC_-_Good_Morning_America_-_Diane_Sawyer.jpg",
                "caption": "Diane Sawyer ",
                "credit": "flickr/<a href='http://www.flickr.com/photos/23843757@N00/194521206/'>Amanda Benham</a>"
            },
            "start_date": {
                "year": "2002"
            },
            "text": {
                "headline": "Crack is Whack",
                "text": "<p>Houston first publicly admitted to drug use in an interview with Diane Sawyer. The singer coined the term \"Crack is Whack,\" saying that she only used more expensive drugs.</p>"
            }
        },
        {
            "media": {
                "url": "https://youtu.be/KLk6mt8FMR0",
                "caption": "Addiction expert, Dr. Drew, talks about Whitney's death and her struggle with addiction.",
                "credit": "CNN"
            },
            "start_date": {
                "year": "2004"
            },
            "text": {
                "headline": "Rehab",
                "text": "<p>Houston entered rehab several times beginning in 2004. She declared herself drug free in an interview with Oprah Winfrey in 2009 but returned to rehab in 2011.</p>"
            }
        },
        {
            "media": {
                "url": "",
                "caption": "",
                "credit": ""
            },
            "start_date": {
                "year": "2005"
            },
            "text": {
                "headline": "Being Bobby Brown",
                "text": "<p>Being Bobby Brown was a reality show starring Brown and wife Whitney Houston. Houston refused to sign for a second season. A clip of her telling Brown to \"Kiss my ass,\" became a running gag on The Soup.</p>"
            }
        },
        {
            "media": {
                "url": "",
                "caption": "",
                "credit": ""
            },
            "start_date": {
                "year": "2010"
            },
            "text": {
                "headline": "A Rocky Comeback",
                "text": "<p>Houston's comeback tour is cut short due to a diminished voice damaged by years of smoking. She was reportedly devastated at her inability to perform like her old self.</p>"
            }
        },
        {
            "media": {
                "url": "//twitter.com/Blavity/status/851872780949889024",
                "caption": "Houston, performing on Good Morning America in 2009.",
                "credit": "<a href='http://commons.wikimedia.org/wiki/File%3AFlickr_Whitney_Houston_performing_on_GMA_2009_4.jpg'>Asterio Tecson</a> via Wikimedia"
            },
            "start_date": {
                "month": "2",
                "day": "11",
                "year": "2012"
            },
            "text": {
                "headline": "Whitney Houston<br/> 1963-2012",
                "text": "<p>Houston, 48, was discovered dead at the Beverly Hilton Hotel on  on Feb. 11, 2012. She is survived by her daughter, Bobbi Kristina Brown, and mother, Cissy Houston.</p>"
            }
        }
    ]
}

var dataObject123 =
{
    "title": {
        "media": {
            "url": "//www.flickr.com/photos/tm_10001/2310475988/",
            "caption": "Whitney Houston performing on her My Love is Your Love Tour in Hamburg.",
            "credit": "flickr/<a href='http://www.flickr.com/photos/tm_10001/'>tm_10001</a>"
        },
        "text": {
            "headline": "Whitney Houston<br/> 1963 - 2012",
            "text": "<p>Houston's voice caught the imagination of the world propelling her to superstardom at an early age becoming one of the most awarded performers of our time. This is a look into the amazing heights she achieved and her personal struggles with substance abuse and a tumultuous marriage.</p>"
        }
    },
    "events": [
        {
            "media":
            {
                "url": "https://youtu.be/fSrO91XO1Ck",
                "caption": "",
                "credit": "<a href=\"http://unidiscmusic.com\">Unidisc Music</a>"
            },
            "start_date":
            {
                "year": "1978"
            },
            "text":
            {
                "headline": "First Recording",
                "text": "At the age of 15 Houston was featured on Michael Zager's song, Life's a Party."
            }
        },
        {
            "media":
            {
                "url": "https://youtu.be/_gvJCCZzmro",
                "caption": "A young poised Whitney Houston in an interview with EbonyJet.",
                "credit": "EbonyJet"
            },
            "start_date":
            {
                "year": "1978"
            },
            "text":
            {
                "headline": "The Early Years",
                "text": "As a teen Houston's credits include background vocals for Jermaine Jackson, Lou Rawls and the Neville Brothers. She also sang on Chaka Khan's, 'I'm Every Woman,' a song which she later remade for the <i>Bodyguard</i> soundtrack which is the biggest selling soundtrack of all time. It sold over 42 million copies worldwide."
            }
        },
        {
            "media": {
                "url": "//twitter.com/Blavity/status/851872780949889024",
                "caption": "Houston, performing on Good Morning America in 2009.",
                "credit": "<a href='http://commons.wikimedia.org/wiki/File%3AFlickr_Whitney_Houston_performing_on_GMA_2009_4.jpg'>Asterio Tecson</a> via Wikimedia"
            },
            "start_date": {
                "month": "2",
                "day": "11",
                "year": "2012"
            },
            "text": {
                "headline": "Whitney Houston<br/> 1963-2012",
                "text": "<p>Houston, 48, was discovered dead at the Beverly Hilton Hotel on  on Feb. 11, 2012. She is survived by her daughter, Bobbi Kristina Brown, and mother, Cissy Houston.</p>"
            }
        }
    ]
}

export function UpdateDataChange(data)
{
    var dataObject2222 = JSON.parse(data);
   // window.timeline = new TL.Timeline('timeline-embed', data);
    window.timeline = new TL.Timeline('timeline-embed', dataObject2222);
}

export function startTimeLine(instance)
{
    // instance is the Blazor component dotnet reference
    window.theInstance = instance;

    // tell the window we want to handle the resize event
    window.addEventListener("resize", resizeCanvasToFitWindow);

    // ... and the mouse events
    window.addEventListener("mousedown", mouseDown);
    window.addEventListener("mouseup", mouseUp);
    window.addEventListener("mousemove", mouseMove);

    //resizeCanvasToFitWindow() es donde se initialize timeline.
    // Call resize now
    resizeCanvasToFitWindow();
}
    
var timeline;
/*This is called whenever the browser (and therefore the canvas) is resized*/

var timeline;
function resizeCanvasToFitWindow()
{
    // DOM element where the Timeline will be attached
    var container = document.getElementById('timeLineDiv');
           
    if (container)
    {       
        //create goal data set with groups
            
            var groupNames = [
            'Relationships',
            'Financial',
            'Career',
            'Business',
            'Fun',
            'Spiritual',
            'Health',
            ];
            var groupStyles = [
            'crimson',
            'green',
            'blue',
            'mediumpurple',
            'orange',
            'gold',
            'firebrick',
            ];
            var groups = new vis.DataSet();

            for (var g = 0; g < groupNames.length; g++)
            {
                groups.add({ id: g, content: groupNames[g] });
        }

            // create a dataset with items
            var items = new vis.DataSet();
            // date months are 0-based index
            var start = new Date(2016, 0, 1);
            var end = new Date(2016, 11, 31);
            var group = 0;
            var i = 0;
            // relationships
            items.add({
                id: i++,
            group: group,
            content: 'Goal 1 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            // financial
            items.add({
                id: i++,
            group: group,
            content: 'Goal 2 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 3 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            // career
            items.add({
                id: i++,
            group: group,
            content: 'Goal 4 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 5 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 6 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 7 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 8 (' + groupNames[group] + ')',
            className: 'done',
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 9 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            // business
            items.add({
                id: i++,
            group: group,
            content: 'Goal 10 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 11 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            // fun
            items.add({
                id: i++,
            group: group,
            content: 'Goal 12 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 13 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            // spiritual
            items.add({
                id: i++,
            group: group,
            content: 'Goal 14 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            // health
            items.add({
                id: i++,
            group: group,
            content: 'Goal 15 (' + groupNames[group] + ')',
            className: groupStyles[group],
            start: start,
            end: end,
            type: 'range',
        });
            items.add({
                id: i++,
            group: group,
            content: 'Goal 16 (' + groupNames[group] + ')',
            className: groupStyles[group++],
            start: start,
            end: end,
            type: 'range',
        });
            
        // Configuration for the Timeline
        var options =
        {
            //minHeight: '25%',
            editable: true,
            moveable: true,
            selectable: true,
            orientation: 'bott',
            min: new Date('2014-01-01'),
            max: new Date('2017-12-31'),
            zoomMin: 1000 * 4 * 60 * 24 * 7,
            margin:
            {
                item: 0,
                axis: 0
            },
            //template: function (item)
            //{
            //    return '<div id="div-id"><input value="edit me" type="text" id="input-id" ></div>'
            //},
        
                groupOrder: 'content', // groupOrder can be a property name or a sorting function
        };

            // Create a Timeline
            if (timeline)
            return;

            timeline = new vis.Timeline(container);
            timeline.setOptions(options);
            timeline.setGroups(groups);
            timeline.setItems(items);
               
    }
}

//Handle the window.mousedown event
function mouseDown(e)
{
    var args = canvasMouseMoveArgs(e);
    theInstance.invokeMethodAsync('OnMouseDown', args);
}

//Handle the window.mouseup event
function mouseUp(e)
{
    var args = canvasMouseMoveArgs(e);
    theInstance.invokeMethodAsync('OnMouseUp', args);
}

//Handle the window.mousemove event
function mouseMove(e)
{
    var args = canvasMouseMoveArgs(e);
    theInstance.invokeMethodAsync('OnMouseMove', args);
}

// Extend the CanvasMouseArgs.cs class (and this) as necessary
function canvasMouseMoveArgs(e)
{
    return
    {
        ScreenX: e.screenX
        ScreenY: e.screenY
        ClientX: e.clientX
        ClientY: e.clientY
        MovementX: e.movementX
        MovementY: e.movementY
        OffsetX: e.offsetX
        OffsetY: e.offsetY
        AltKey: e.altKey
        CtrlKey: e.ctrlKey
        Button: e.button
        Buttons: e.button
        Bubbles: e.bubbles
    };
}