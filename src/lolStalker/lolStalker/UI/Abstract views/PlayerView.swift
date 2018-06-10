//
//  PlayerView.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/7/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

protocol PlayerViewDelegate {
    func didSetPlayer(player: Player, form: PlayerView)
    func cancelPressed(form: PlayerView)
}

class PlayerView: UIView {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
    var delegate: PlayerViewDelegate?
    
    ////////////////////////////////////
    //Global Variables
    ////////////////////////////////////
    var player: Player? {
        didSet{
            
        }
    }
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let cancelBtn: UIButton = {
        let button = UIButton()
        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
        button.setTitle("CANCEL", for: .normal)
        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 12, referenceHeight: nil, referenceWidth: nil))
        button.addTarget(self, action: #selector(cancelPressed), for: .touchUpInside)
        return button
    }()
    
    
    ////////// END OF CONTROLS /////////
    
    override init(frame: CGRect) {
        super.init(frame: frame)
        setupView()
        setupConstraints()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setupView() {
        backgroundColor = UIColor(hex: "#010A13")
    }
    
    func setupConstraints() {
        // MARK: Add subviews
        addSubview(cancelBtn)
        
        // MARK: Disable frames
        cancelBtn.translatesAutoresizingMaskIntoConstraints = false
        
        // MARK: Constraints
        cancelBtn.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 76, referenceWidth: nil, originalWidth: nil)).isActive = true
        cancelBtn.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 21.36, referenceHeight: nil, originalHeight: nil)).isActive = true
        cancelBtn.topAnchor.constraint(equalTo: topAnchor).isActive = true
        cancelBtn.leftAnchor.constraint(equalTo: leftAnchor).isActive = true
    }
    
    @IBAction func cancelPressed(sender: AnyObject) {
        delegate?.cancelPressed(form: self)
    }
}
