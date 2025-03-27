MODULE Modle2

VAR num join1 := 0;
VAR num join2 := 0;
VAR num join3 := 0;
VAR num join4 := 0;
VAR num join5 := 0;
VAR num join6 := 0;
               

VAR num xl := 0;
VAR num yl := 0;
VAR num zl := 0;
VAR num rxl := 0;
VAR num ryl := 0;
VAR num rzl := 0;


VAR num cir1 := 0;
VAR num cir2 := 0;
VAR num cir3 := 0;



PROC exercise()
VAR jointtarget TargetPos; 
VAR num i;                  
VAR robtarget   current_pos;
VAR robtarget   start_pos;
VAR robtarget   end_pos;
VAR num rz;
VAR num ry;
VAR num rx;    
    
!VAR egmident egmID1;
!VAR pose corr_frame_offs := [[0,0,0],[1,0,0,0]];  

  

!        EGMGetId egmID1; 
!      EGMActPose egmID1\Tool:=tool0,corr_frame_offs,EGM_FRAME_WORLD,
!            corr_frame_offs,EGM_FRAME_WORLD
!            \LpFilter:=0.5\MaxSpeedDeviation:=60;



    
    
    
    WHILE TRUE DO
    
        current_pos := CRobT(\Tool:=tool0 \WObj:=wobj0);
        TargetPos := CJointT();  
        start_pos := current_pos;
        end_pos := current_pos;
        
     
rz := EulerZYX(\Z, current_pos.rot); 
ry := EulerZYX(\Y, current_pos.rot);  
rx := EulerZYX(\X, current_pos.rot); 
        
        

 IF join1 = 1 THEN
         TargetPos.robax.rax_1 := TargetPos.robax.rax_1 + 5;
         join1 := 0;
                 MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join2 = 1 THEN
             TargetPos.robax.rax_2 := TargetPos.robax.rax_2 + 5;
              join2 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join3 = 1 THEN
             TargetPos.robax.rax_3 := TargetPos.robax.rax_3 + 5;
              join3 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join4 = 1 THEN
             TargetPos.robax.rax_4 := TargetPos.robax.rax_4+ 5;
              join4 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join5 = 1 THEN
             TargetPos.robax.rax_5 := TargetPos.robax.rax_5 + 5;
        MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
              join5 := 0;
        ELSEIF join6 =  1 THEN
             TargetPos.robax.rax_6 := TargetPos.robax.rax_6 + 5;
              join6 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join1 = 2 THEN
         TargetPos.robax.rax_1 := TargetPos.robax.rax_1 - 5;
         join1 := 0;
                 MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join2 = 2 THEN
             TargetPos.robax.rax_2 := TargetPos.robax.rax_2 - 5;
              join2 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join3 = 2 THEN
             TargetPos.robax.rax_3 := TargetPos.robax.rax_3 - 5;
              join3 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join4 = 2 THEN
             TargetPos.robax.rax_4 := TargetPos.robax.rax_4- 5;
              join4 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join5 = 2 THEN
             TargetPos.robax.rax_5 := TargetPos.robax.rax_5 - 5;
              join5 := 0;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join6 =  2 THEN
            
             TargetPos.robax.rax_6 := TargetPos.robax.rax_6 - 5;
                     MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
              join6 := 0;
        ENDIF


        
        IF xl = 1 THEN
            current_pos.trans.x := current_pos.trans.x + 5;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                xl := 0; 
        ELSEIF yl = 1 THEN
            current_pos.trans.x := current_pos.trans.y + 5;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            yl :=0;
        ELSEIF zl = 1 THEN
            current_pos.trans.x := current_pos.trans.z + 5;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    zl :=0;
            ELSEIF rxl = 1 THEN
           rx := rx+ 5;
           current_pos.rot := OrientZYX(rz, ry, rx);
                   MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    rxl :=0;
            ELSEIF ryl = 1 THEN
            ry := ry+ 5;
             current_pos.rot := OrientZYX(rz, ry, rx);
                     MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    ryl := 0;
            ELSEIF rzl = 1 THEN
            rz := rz+ 5;
            current_pos.rot := OrientZYX(rz, ry, rx);
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    rzl := 0;
            ELSEIF xl = 2 THEN
            current_pos.trans.x := current_pos.trans.x - 5;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                        xl := 0;
        ELSEIF yl = 2 THEN
            current_pos.trans.x := current_pos.trans.y - 5;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    yl := 0;
        ELSEIF zl = 2 THEN
            current_pos.trans.x := current_pos.trans.z - 5;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    zl := 0;
            ELSEIF rxl = 2 THEN
           rx := rx- 5;
           current_pos.rot := OrientZYX(rz, ry, rx);
                   MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                        rxl := 0;
            ELSEIF ryl = 2 THEN
            ry := ry- 5;
             current_pos.rot := OrientZYX(rz, ry, rx);
                     MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                        ryl := 0;
            ELSEIF rzl=2  THEN
            rz := rz- 5;
            current_pos.rot := OrientZYX(rz, ry, rx);
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
                    rzl := 0;
        ENDIF
        
        
        
                IF join1 = 3 THEN
         TargetPos.robax.rax_1 := TargetPos.robax.rax_1 + 1;
         
                 MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join2 = 3 THEN
             TargetPos.robax.rax_2 := TargetPos.robax.rax_2 + 1;
       
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join3 = 3 THEN
             TargetPos.robax.rax_3 := TargetPos.robax.rax_3 + 1;
          
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join4 = 3 THEN
             TargetPos.robax.rax_4 := TargetPos.robax.rax_4+ 1;
          
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join5 = 3 THEN
             TargetPos.robax.rax_5 := TargetPos.robax.rax_5 + 1;
        MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
             
        ELSEIF join6 =  3 THEN
             TargetPos.robax.rax_6 := TargetPos.robax.rax_6 + 1;
              
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join1 = 4THEN
         TargetPos.robax.rax_1 := TargetPos.robax.rax_1 - 1;
                 MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join2 = 4THEN
             TargetPos.robax.rax_2 := TargetPos.robax.rax_2 - 1;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join3 = 4 THEN
             TargetPos.robax.rax_3 := TargetPos.robax.rax_3 - 1;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join4 = 4THEN
             TargetPos.robax.rax_4 := TargetPos.robax.rax_4- 1;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join5 = 4 THEN
             TargetPos.robax.rax_5 := TargetPos.robax.rax_5 - 1;
                      MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ELSEIF join6 =  4 THEN
            
             TargetPos.robax.rax_6 := TargetPos.robax.rax_6 - 1;
                     MoveAbsJ TargetPos, v500, fine, tool0 \WObj:=wobj0;
        WaitRob \InPos;
        ENDIF


        
        IF xl = 3 THEN
            current_pos.trans.x := current_pos.trans.x + 1;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
        ELSEIF yl = 3 THEN
            current_pos.trans.x := current_pos.trans.y + 1;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
        ELSEIF zl = 3 THEN
            current_pos.trans.x := current_pos.trans.z + 1;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF rxl = 3 THEN
           rx := rx+ 1;
           current_pos.rot := OrientZYX(rz, ry, rx);
                   MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF ryl = 3 THEN
            ry := ry+ 1;
             current_pos.rot := OrientZYX(rz, ry, rx);
                     MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF rzl = 3 THEN
            rz := rz+ 1;
            current_pos.rot := OrientZYX(rz, ry, rx);
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF xl = 4THEN
            current_pos.trans.x := current_pos.trans.x - 1;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
        ELSEIF yl = 4THEN
            current_pos.trans.x := current_pos.trans.y - 1;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
        ELSEIF zl = 4THEN
            current_pos.trans.x := current_pos.trans.z - 1;
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF rxl = 4 THEN
           rx := rx- 1;
           current_pos.rot := OrientZYX(rz, ry, rx);
                   MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF ryl = 4 THEN
            ry := ry- 1;
             current_pos.rot := OrientZYX(rz, ry, rx);
                     MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
            ELSEIF rzl=4  THEN
            rz := rz- 1;
            current_pos.rot := OrientZYX(rz, ry, rx);
                    MoveL current_pos, v500,fine, tool0 \WObj:=wobj0; 
        ENDIF

        
        



        IF cir1 = 1 THEN
            start_pos.trans.x := current_pos.trans.x - 100;
            end_pos.trans.x := current_pos.trans.x - 200;
         MoveC start_pos,end_pos,v100,z100,tool0\WObj:=wobj0;
         cir1 := 0;
        ELSEIF cir2 = 1 THEN 
            start_pos.trans.y := current_pos.trans.y - 60;
            end_pos.trans.y := current_pos.trans.y - 120;
         MoveC start_pos,end_pos,v100,fine,tool0\WObj:=wobj0;
         cir2 := 0;
         ELSEIF cir3 = 1 THEN 
            start_pos.trans.z := current_pos.trans.z - 70;
            end_pos.trans.z := current_pos.trans.z - 140;
         MoveC start_pos,end_pos,v100,fine,tool0\WObj:=wobj0;
          cir2 := 0;
        ENDIF
     
        
        
        
        
        
    ENDWHILE
    
   
ENDPROC
ENDMODULE
    
    
    
    
    
    
    
