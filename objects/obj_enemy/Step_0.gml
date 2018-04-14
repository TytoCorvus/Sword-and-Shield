/// Enemy functionality.
image_xscale = dir; 
hsp = spd * dir; 

//add falling.
if (vsp < 15){
	vsp += grav;
}

//vertical collisions
if (place_meeting(x,y+vsp,obj_block)){
    while (!place_meeting(x,y+sign(vsp),obj_block)){
        y+=sign(vsp);
    }
    vsp = 0;
}


//Horizontal colision
if (place_meeting(x+hsp,y,obj_block)){
    while (!place_meeting(x+sign(hsp),y,obj_block)){
        x+=sign(hsp);
    }
    hsp = 0;
	dir *= -1; 
}

x += hsp;
y += vsp;