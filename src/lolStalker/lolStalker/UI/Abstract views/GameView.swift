//
//  GameView.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/7/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

protocol GameViewDelegate {
    //    func didPressSignup(form: GameView)
    //    func didPressAlreadyHaveAccount(form: GameView)
    func didSetGame(game: Game, form: GameView)
}

class GameView: UIView {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
    var delegate: GameViewDelegate?
    
    ////////////////////////////////////
    //Global Variables
    ////////////////////////////////////
    
    var game: Game? {
        didSet{
            if let game = game {
                delegate?.didSetGame(game: game, form: self)
            }
            
            if let team1 = game?.Team1 {
                topView.team = team1
            }
            
            if let team2 = game?.Team2 {
                bottomView.team = team2
            }
        }
    }
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let topView: TeamTableView = {
        let team = TeamTableView()
        team.alwaysBounceVertical = false
        team.alwaysBounceHorizontal = false
        return team
    }()
    
    let vsView: UIView = {
        let view = UIView()
//        view.backgroundColor = UIColor.green
        // Create vslabel
        let vsLabel: UILabel = {
            let label = UILabel()
            label.text = "VS"
            label.textColor = UIColor(hex: "#95989A")
            label.font = UIFont.italicSystemFont(ofSize: Helper.getFontOf(xdFont: 40, referenceHeight: nil, referenceWidth: nil))
            label.translatesAutoresizingMaskIntoConstraints = false
            return label
        }()
        
        view.addSubview(vsLabel)
        
        vsLabel.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        vsLabel.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        return view
    }()
    
    
    let bottomView: TeamTableView = {
        let team = TeamTableView()
        team.alwaysBounceVertical = false
        team.alwaysBounceHorizontal = false
        return team
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
        topView.team = game?.Team1
        bottomView.team = game?.Team2
    }
    
    func setupConstraints() {
        // MARK: Add subviews
        addSubview(topView)
        addSubview(vsView)
        addSubview(bottomView)
        
        // MARK: Disable frames
        topView.translatesAutoresizingMaskIntoConstraints = false
        vsView.translatesAutoresizingMaskIntoConstraints = false
        bottomView.translatesAutoresizingMaskIntoConstraints = false
        
        // MARK: Constraints
//        let x:CGFloat = CGFloat(heightAnchor)
//        if #available(iOS 11, *) {
//            let guide = safeAreaLayoutGuide
//            let safeAreaHeight = UIScreen.main.bounds.height - ((UIApplication.shared.keyWindow?.safeAreaInsets.top)! + (UIApplication.shared.keyWindow?.safeAreaInsets.bottom)!)
//            vsView.centerXAnchor.constraint(equalTo: guide.centerXAnchor).isActive = true
//            vsView.centerYAnchor.constraint(equalTo: guide.centerYAnchor).isActive = true
//            vsView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 98, referenceHeight: 598, originalHeight: safeAreaHeight)).isActive = true
//            vsView.widthAnchor.constraint(equalTo: guide.widthAnchor).isActive = true
//
//            // TOP AND BOTTOM VIEW
//            topView.view.topAnchor.constraint(equalTo: guide.topAnchor).isActive = true
//            topView.view.widthAnchor.constraint(equalTo: guide.widthAnchor).isActive = true
//            bottomView.view.bottomAnchor.constraint(equalTo: guide.bottomAnchor).isActive = true
//            bottomView.view.widthAnchor.constraint(equalTo: guide.widthAnchor).isActive = true
//        } else {
//            vsView.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
//            vsView.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
//            vsView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 98, referenceHeight: nil, originalHeight: nil)).isActive = true
//            vsView.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
//
//
//            topView.view.topAnchor.constraint(equalTo: topAnchor).isActive = true
//            topView.view.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
//            bottomView.view.bottomAnchor.constraint(equalTo: bottomAnchor).isActive = true
//            bottomView.view.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
////        }
//
//        topView.view.bottomAnchor.constraint(equalTo: vsView.topAnchor).isActive = true
//        bottomView.view.topAnchor.constraint(equalTo: vsView.bottomAnchor).isActive = true
        
        vsView.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        vsView.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
        vsView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 98, referenceHeight: nil, originalHeight: nil)).isActive = true
        vsView.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        
        
        topView.topAnchor.constraint(equalTo: topAnchor).isActive = true
        topView.bottomAnchor.constraint(equalTo: vsView.topAnchor).isActive = true
        topView.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        
        bottomView.topAnchor.constraint(equalTo: vsView.bottomAnchor).isActive = true
        bottomView.bottomAnchor.constraint(equalTo: bottomAnchor).isActive = true
        bottomView.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
    }
}
